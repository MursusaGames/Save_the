using System;
using UnityEngine;
using Unity.Notifications.Android;

public class PushSystem : MonoBehaviour
{
    int id;
    // ToDo: переделать после добавления локализации
    //public void SendLocalizedPush(string titleKey, string textKey)
    //{
    //    SendDelayLocalizedPush(1, DateTime.UtcNow, titleKey, textKey);
    //}

    //public void SendDelayLocalizedPush(int id, DateTime fireTime, string titleKey, string textKey)
    //{
    //    string title = LocalizationSystem.GetText(titleKey);
    //    string message = LocalizationSystem.GetText(textKey);
    //    LocalNotification.CreateNotification(title, message, id, fireTime);
    //}

    public void SendDelayPush(int id, DateTime fireTime, string title, string message)
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
        var notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = message;
        notification.FireTime = fireTime;

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
        
    }

    public void SendPush(string title, string text)
    {
        SendDelayPush(1, DateTime.UtcNow, title, text);
    }

    public void Cancel(int id)
    {
        AndroidNotificationCenter.CancelAllNotifications();
    }
}
