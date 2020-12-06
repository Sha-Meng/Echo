using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using UnityEngine.UI;

public class Echo : MonoBehaviour
{
    // 定义套接字
    Socket socket;
    public InputField input;
    public Text text;

    // 定义连接按钮
    public void Connection()
    {
        // 判断是否连接
        if (socket == null || !socket.Connected)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // connect
            socket.Connect("127.0.0.1", 8888);
        }
    }

    public void Send()
    {
        // 判断是否连接
        if (socket == null || !socket.Connected)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // connect
            socket.Connect("127.0.0.1", 8888);
        }
        // 获取输入框文字
        string sendStr = input.text;
        byte[] sendByte = System.Text.Encoding.Default.GetBytes(sendStr);
        socket.Send(sendByte);

        // 获取服务器返回的数据
        byte[] readBuff = new byte[1024];
        int count = socket.Receive(readBuff);
        string recvStr = System.Text.Encoding.Default.GetString(readBuff, 0, count);
        text.text = recvStr;

        // 关闭连接
        socket.Close();
    }
}
