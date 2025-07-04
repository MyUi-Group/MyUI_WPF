using MyUi.Controls.Message.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace MyUi.Controls
{
    public class MyMessage : ContentControl
    {
        [Bindable(true)]
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(MyMessage));

        internal MyMessage()
        {
            Loaded += Message_Loaded;
        }

        private async void Message_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.Parent is MessageHost host)
            {
                await Task.Delay(TimeSpan.FromSeconds(Time));
                host.Items.Remove(this);
            }
        }

        public double Time { get; set; }

        [Bindable(true)]
        public MessageType Type
        {
            get { return (MessageType)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        
        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(MessageType), typeof(MyMessage), new PropertyMetadata(MessageType.Success));

    }
}
