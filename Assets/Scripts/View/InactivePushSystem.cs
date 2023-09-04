using System;
using UnityEngine;


public class InactivePushSystem : MonoBehaviour
{
    private const int IdPushOffset = 1000;

    [SerializeField] private InactivePushItem[] _inactivePushItems;
    [SerializeField] private PushSystem _pushSystem;


    private void OnApplicationPause(bool pause)
    {
        if (pause)
            SendDelayPushes();
        else
            CancelDelayPushes();
    }

    private void SendDelayPushes()
    {
        for (int i = 0; i < _inactivePushItems.Length; i++)
        {
            int newPushId = i + IdPushOffset;
            DateTime pushTime = DateTime.UtcNow.AddSeconds(_inactivePushItems[i].InactiveTime);

            _pushSystem.SendDelayPush(newPushId,
                pushTime,
                _inactivePushItems[i].TitleMessage,
                _inactivePushItems[i].TextMessage);
        }
    }

    private void CancelDelayPushes()
    {
        for (int i = 0; i < _inactivePushItems.Length; i++)
            _pushSystem.Cancel(i + IdPushOffset);
    }
}
