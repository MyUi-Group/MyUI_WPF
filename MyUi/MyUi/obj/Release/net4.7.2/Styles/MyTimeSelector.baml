   M S B A M L   `   `   `  ���� ?  ;MyUi, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MyUi.ControlsMyUi.Controls  %clr-namespace:MyUi.Args	MyUi.Args  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   MyTimeSelectButtonStyle  �� 
TargetType&     MyUi.Controls.MyTimeSelectButton �� Property �� Value  Triangle_Fill    MyUi.Controls.ElementExten  TimeSelectButton_HoverBg �� 
TargetType ��Name �� CornerRadius �� RelativeSource �� Path ��Name	 �� Triggers
 P� Property P� Value �� 
TargetName  CalendarItemButtonHover  TimeListBoxItemsStyle J� SnapsToDevicePixels � UseLayoutRounding ��Name  MyTimeSelectorStyle"   MyUi.Controls.MyTimeSelector  CommonBorder_Color  Common_Color A� Rows ��Name �� Triggers �� BasedOn�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     "Myclr-namespace:MyUi.Controls  #MyEventclr-namespace:MyUi.Args  %u  &	        &	 �    7   &	 �    7  7  7  '  *    7  �� "    .���  � ��$ Center=���  � ��$ Center=���  � ��# �  ��  � ��
 �������  � ��$ 14(���  � ��$ 28����  �@ CornerRadius$ 0����  �@ MouseHoverBackGround# �  ��  � �� �� "   .R��� $ border��#��z��#��z��#��z�� ��  �� *TemplatedParent+$$ (My:ElementExten.CornerRadius)�._��� $ 
NormalText��#��z��#��z��	 P� 
 �@J�IsMouseOver$
 true��. ���  �@�Cursor$
 Hand���� $ border�� ��  �� *TemplatedParent+$, &(My:ElementExten.MouseHoverBackGround)� � ��P� 
 �@��
IsSelected$
 true��. ���  �@�Cursor$
 Hand����  � ��$
 Bold"��� $ border��# �   � ���� "  ��.���  � ��8   ��  � ��
 ���� ��  � ��$ 0q���  � �� �� " ��.R��� #��z��#��z��#��z��# z # z ._��� $ PART_ScrollViewer��.���� �� "   .���  � ��# �  ��  � ��# �  ��  �@J�SnapsToDevicePixels$
 True����  �@�UseLayoutRounding$
 True����  � �� �� "  .R��� #��z��#��z��#��z��# z # z ._�A� $ 1��.+��� $ 	PART_Hour��8��  �� $ PART_Minute��#��z��$��1,0,0,0q�8�� �� $ PART_Second��#��z��$��1,0,0,0q�8��  P� 
 � {�$ False��. ���  �@J�Opacity$
 0.76Q��� 8   "   