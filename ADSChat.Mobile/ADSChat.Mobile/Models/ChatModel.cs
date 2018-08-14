using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using ADSChat.Mobile.Annotations;
using Xamarin.Forms;

namespace ADSChat.Mobile.Models
{
    public class ChatModel:INotifyPropertyChanged
    {
        public string username { get; set; }
        public string message { get; set; }

        private TextAlignment _textAlignment;

        public TextAlignment TextAlignment
        {
            get { return _textAlignment;}
            set { _textAlignment = value;OnPropertyChanged(nameof(TextAlignment)); } }
        private Color _textColor;
        public Color TextColor
        {
            get { return _textColor;}
            set { _textColor = value;OnPropertyChanged(nameof(TextColor)); }
        }


        private bool _isRecived;
        public bool isRecived
        {
            get { return _isRecived; }
            set { _isRecived = value; OnPropertyChanged(nameof(isRecived)); }
        }



        public ChatMessageType MessageType { get; set; } = ChatMessageType.SentMessage;

        public ChatModel(string _user,string _message,ChatMessageType _type)
        {
            this.message = _message;
            this.username = _user;
            this.MessageType = _type;
            this.isRecived = _type == ChatMessageType.RecivedMessage?true:false;
            switch (MessageType)
            {
                case ChatMessageType.SentMessage:
                    TextColor = Color.White;
                    this.TextAlignment = TextAlignment.End;
                    break;
                case ChatMessageType.RecivedMessage:
                    TextColor = Color.AliceBlue;
                    this.TextAlignment = TextAlignment.Start;
                    break;
                case ChatMessageType.Info:
                    TextColor = Color.Blue;
                    this.TextAlignment = TextAlignment.Center;
                    break;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum ChatMessageType
    {
        SentMessage,RecivedMessage,Info
    }
}
