   M S B A M L   `   `   `  ����?  ;MyUi, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MyUi.ControlsMyUi.Controls  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   DefaultIcon  B� FillRule  MyButtonStyle �� 
TargetType     MyUi.Controls.ElementExten �� Property �� Value �� 	Resources  Key �� 
TargetType ��Name J� Opacity �� CornerRadius	 �� RelativeSource
 �� Path ��Name �� Triggers P� Property P� Value �� 
TargetName F�Name J� RenderTransformOrigin �� Stretch �� Angle  Common_DisabledColor �� Triggers  
Main_Color  NormalButtonTemplate  Error_Color  
Warn_Color  Sucess_Color 	 CalendarItemButtonSelect 
 IconButtonTemplate �� BasedOn�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      "Myclr-namespace:MyUi.Controls  5      %�  &	        &	 #    7   '�� �    7  B� 5      $����M12,18A6,6,0,0,1,6,12C6,11,6.25,10.03,6.7,9.2L5.24,7.74C4.46,8.97,4,10.43,4,12A8,8,0,0,0,12,20L12,23 16,19 12,15 M12,4L12,1 8,5 12,9 12,6A6,6,0,0,1,18,12C18,13,17.75,13.97,17.3,14.8L18.76,16.26C19.54,15.03,20,13.57,20,12A8,8,0,0,0,12,4zC�5   	   $  NonZero=�5   	   �� 5
      " ��6"   .�5   
   ��  �@  CornerRadius$ 5��69   �� 5   
    � ��$ 0q�6,   �� 5   
    �@J�Opacity$	 0.8Q�6$   �� 5   
    �@�FocusVisualStyle 6-   Z� �� 5   
    �@�Cursor$
 Hand��6#   �� 5   
    �@J�SnapsToDevicePixels$
 true��60    5   
   ���� 5      NormalButtonTemplate " ��6;   .R�5      �� $ PART_Border��5      #��z��5      #��z��5      #��z��5      # z 5       5      �� 	 �� *TemplatedParent+$$
 (My:ElementExten.CornerRadius)�._�5      � #��z��5      #��z��5      #��z��5      .+�5      �� $ PART_Content��5      $��1��5       #��z��5!      #��z��5"      5#      5$       5%      P� 5&       �@J�IsMouseOver$
 True��65   . �5'      �� $ PART_Border��6!    �@J�Opacity$ 1Q�6M   5(      P� 5)       � ��$
 True��63   . �5*      �� $ PART_Border��6!    �@J�Opacity$ 1Q�6M   5+      P� 5,       � {�$ False��63   . �5-      ��  �@J�Opacity$
 0.65Q�64   5.      50      �� 52      IconButtonTemplate " ��69   .R�54      �� $ border��55      
������ #��z��57      #��z��58       59      �� 	 �� *TemplatedParent+$$
 (My:ElementExten.CornerRadius)�._�5:      � #��z��5;      #��z��5<      #��z��5=      .+�5>      F� $
 path��5?      $��Center=�5B      $��Center=�5C      #��z��5E      $ 0.5,0.5&�5F      $ Uniform=�5G      ��5@      �� 	 �� *TemplatedParent+$ 
 (My:ElementExten.IcoWidth)���5A      �� 	 �� *TemplatedParent+$!
 (My:ElementExten.IcoHeight)���5D      �� 	 �� *TemplatedParent+$#
 (My:ElementExten.IcoPathData)�z�5H      V� 5I   "   .~�5J   &   �� �� 5K   &   �� 5L   &    66   �� 	 �� *TemplatedParent+$ 
 (My:ElementExten.IcoAngle)�T� 5M   &   5N   #   5P      5S      5T       5U      P� 5V       �@J�IsMouseOver$
 true��65   . �5W      ��  �@�Cursor$
 Hand��63   �� 5X      $
 path��6!    6C   �� 	 �� *TemplatedParent+$,
 &(My:ElementExten.MouseHoverBackGround)� � ��5Y      P� 5Z       � ��$
 true��63   . �5[      �� $
 path��6!    6C   �� 	 �� *TemplatedParent+$,
 &(My:ElementExten.MouseHoverBackGround)� � ��5\      P� 5]       � {�$ false��63   . �5^      ��  �@�Cursor$ No��63   �� 5_      $
 path��6!   # �  6C    � ��5`      5b      5d       5e   
   P� 5f       �@  
ButtonType$ TypeText��6<   . �5g      ��  � �� 6/   Z� �� 5h       � ��# �  6/   �� 5i       � ��# �  6-   5j      P� 5k       �@  
ButtonType$ Primary��6<   . �5l      ��  � ��# �  6/   �� 5m       � ��
 �����6/   �� 5n       � ��# �  6-   5o      P� 5p       �@  
ButtonType$ Error��6<   . �5q      ��  � ��# �  6/   �� 5r       � ��
 �����6/   �� 5s       � ��# �  6-   5t      P� 5u       �@  
ButtonType$ Warning��6<   . �5v      ��  � ��# �  6/   �� 5w       � ��
 �����6/   �� 5x       � ��# �  6-   5y      P� 5z       �@  
ButtonType$ Success��6<   . �5{      ��  � ��# �  6/   �� 5|       � ��
 �����6/   �� 5}       � ��# �  6-   5~      P� 5�       �@  
ButtonType$
 Icon��6<   . �5�      ��  �@  IcoPathData8   6@   �� 5�       �@  MouseHoverBackGround# � 	 6I   �� 5�       � ��# �  6/   �� 5�       � ��
 ���� 60   �� 5�       � ��$ 0q�64   �� 5�       � ��# � 
 6-   5�      5�      �� 5�      8   " ��65   5�      