using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using cn.jpush.api;
using cn.jpush.api.push;
using cn.jpush.api.report;
using cn.jpush.api.common;
using cn.jpush.api.util;

namespace JPushClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //String result;
            String master_secret = "8d182844403f3d9f100d21ec";
            String app_key = "51260cf224b010f4c0b0ac67";
            //int sendno = 9;
            JPushClient client = new JPushClient(app_key, master_secret);
            MessageResult result = null;

            NotificationParams notifyParams = new NotificationParams();
            CustomMessageParams customParams = new CustomMessageParams();

            //notifyParams.
            Dictionary<String, Object> extras = null;

            Console.WriteLine("*****发送带alias通知******");

            notifyParams.addPlatform(DeviceEnum.Android);
            notifyParams.ReceiverType = ReceiverTypeEnum.ALIAS;
            notifyParams.ReceiverValue = "AB6F93F8E6C64AB58BD570A9AF31BF15";
            notifyParams.SendNo = 257;
            //notifyParams.OverrideMsgId = "2";

            UTF8Encoding utf8 = new UTF8Encoding();
            string unicodeString = "中国";
            byte[] encodeBytes = utf8.GetBytes(unicodeString);
            string test = Encoding.UTF8.GetString(encodeBytes);
            result = client.sendNotification("中国xaut", notifyParams, extras);
            Console.WriteLine("sendNotificationAll:**返回状态：" + result.getErrorCode().ToString() +
                          "  **返回信息:" + result.getErrorMessage() +
                          "  **Send No.:" + result.getSendNo() +
                          "  msg_id:" + result.getMessageId() +
                          "  频率次数：" + result.getRateLimitQuota() +
                          "  可用频率：" + result.getRateLimitRemaining() +
                          "  重置时间：" + result.getRateLimitReset());


            Console.WriteLine("*****发送带alias消息******");
            customParams.addPlatform(DeviceEnum.Android);
            customParams.ReceiverType = ReceiverTypeEnum.ALIAS;
            customParams.ReceiverValue = "alias_api";
            customParams.SendNo = 256;
            result = client.sendCustomMessage("send custom mess", "alias notify content", customParams, extras);
            Console.WriteLine("sendCustomMessage:**返回状态：" + result.getErrorCode().ToString() +
                          "  **返回信息:" + result.getErrorMessage() +
                          "  **Send No.:" + result.getSendNo() +
                          "  msg_id:" + result.getMessageId() +
                          "  频率次数：" + result.getRateLimitQuota() +
                          "  可用频率：" + result.getRateLimitRemaining() +
                          "  重置时间：" + result.getRateLimitReset());

        }
    }
}
