using System.Collections;
using UnityEngine;
using System.ComponentModel;
using System.IO;
using System.Net.Mail;
using UnityAtoms.BaseAtoms;

public class Mail : MonoBehaviour
{
    [SerializeField] StringVariable _recieverMail;
    // I would make these values settable maybe by a constructor or method
    private const string emailAdressFrom = "smtpEmail";
    private const string password = "password";
    private const string smtpClientAdress = "smtpClientAddress";
    private const int smtpClientPort = 123;
    private const string emailFrom = "EMAIL FROM TEXT";
    private const string emailSubject = "SUBJECT";
    private const string emailBody = "BODY";

    [SerializeField] VoidEvent MailSendRequestEvent;
    [SerializeField] VoidEvent OnMailSendSuccessfully;

    [SerializeField] StringVariable[] _attachmentPaths;

    private void Start()
    {
        MailSendRequestEvent.Register(Send);
    }
    private void OnDestroy()
    {
        MailSendRequestEvent.Unregister(Send);
    }

    public void Send()
    {
        StartCoroutine(SendCouroutine());

    }
    IEnumerator SendCouroutine()
    {
        using MailMessage emailMessage = new MailMessage();

        emailMessage.IsBodyHtml = true;
        emailMessage.From = new MailAddress(emailAdressFrom, emailFrom);
        emailMessage.To.Add(new MailAddress(_recieverMail.Value));
        emailMessage.Subject = emailSubject;
        emailMessage.Body = emailBody;
        emailMessage.Priority = MailPriority.Normal;

        foreach (var attachment in _attachmentPaths)
        {
            emailMessage.Attachments.Add(new Attachment($"{Application.persistentDataPath}/{attachment.Value}"));
        }

        using SmtpClient MailClient = new SmtpClient(smtpClientAdress, smtpClientPort);
        MailClient.EnableSsl = true;
        MailClient.Credentials = new System.Net.NetworkCredential(emailAdressFrom, password);
        MailClient.SendCompleted += new
        SendCompletedEventHandler(SendCompletedCallback);
        MailClient.SendCompleted += (s, e) =>
        {
            MailClient.Dispose();
            emailMessage.Dispose();
        };

        while (Application.internetReachability == NetworkReachability.NotReachable)
        {
            yield return new WaitForSeconds(1f);
        }

        MailClient.SendAsync(emailMessage, null);
    }

    private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
    {
        if (e.Cancelled)
        {
            Debug.Log($"Email canceled line 72");
        }
        if (e.Error != null)
        {
            Debug.Log($"Email Error line 77\n {e.Error}");
        }
        else
        {
            Debug.Log($"Email Sent line 82");
            OnMailSendSuccessfully.Raise();
        }
    }

    public void DeletePersistant()
    {
        StartCoroutine(DeletePersistantCouroutine());
    }
    IEnumerator DeletePersistantCouroutine()
    {
        yield return new WaitForSeconds(5);
        var info = new DirectoryInfo(Application.persistentDataPath);
        var fileInfo = info.GetFiles();
        if (fileInfo.Length > 0)
        {
            foreach (var item in fileInfo)
            {
                item.Delete();
            }
        }
    }
}