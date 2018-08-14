using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using ADSChat.Mobile.Annotations;

namespace ADSChat.Mobile.Models
{
    public class ListPageModel:INotifyPropertyChanged
    {


        public ListPageModel()
        {
            Chats = new ObservableCollection<ChatModel>();
        }

        private ObservableCollection<ChatModel> _chats;

        public ObservableCollection<ChatModel> Chats
        {
            get => _chats;
            set
            {
                _chats = value;
                OnPropertyChanged(nameof(Chats));
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
