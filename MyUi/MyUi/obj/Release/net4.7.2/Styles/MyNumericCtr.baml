   M S B A M L   `   `   `  ���� ?  ;MyUi, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MyUi.ControlsMyUi.Controls  %clr-namespace:MyUi.Args	MyUi.Args  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   MyNumericStyle  �� 
TargetType     MyUi.Controls.MyNumericCtr �� 	Resources  Key �� 
TargetType ��Name �� CornerRadius �� RelativeSource �� Path � ColumnDefinitions ��Name    MyUi.Controls.ElementExten	   
ButtonType
   IcoAngle   	IcoHeight   IcoPathData   IcoWidth ��Name ��Name   TextBoxType   	Watermark �� IsInputMethodEnabled �� 
IsReadOnly �� AncestorType �� Triggers P� 
SourceName P� Property P� Value �� 
TargetName �� Property �� Value � RowDefinitions �� Triggers  CommonBorder_Color  Common_Color  Comon_Font_Color & "MyNumeric_type_One_ControlTemplate & "MyNumeric_type_Tow_ControlTemplate �� BasedOn�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     "Myclr-namespace:MyUi.Controls  #MyEventclr-namespace:MyUi.Args  %�  &	        '   �    7   �� "     ���� &"MyNumeric_type_One_ControlTemplate "   .R��� $ bg��#��z��#��z��#��z�� ��  �� *TemplatedParent+$$ (My:ElementExten.CornerRadius)�._��  �� $
��auto ��� $
��auto ��� $��* ��� $
��auto ��� $
��auto �.+��� $ PART_Reduce_Border��$��0��$��40��$
	 Icon��$	
 180��$ 2��$z tM801.171 547.589H222.83c-17.673 0-32-14.327-32-32s14.327-32 32-32h578.341c17.673 0 32 14.327 32 32s-14.327 32-32 32z��$ 13��#��z���� $ mid_rect_one��$��1��$��1��#��z��� $��2��#��z��$��Stretch=�#��z��.+��� $ PART_ContentHost��$��Stretch=�$��Center=�#��z��#��z��$ Number��$  ��$��0q�#��z��#��z��$ False�� ��  ��  My:MyNumericCtr$ 
IsReadOnly�����  ��  My:MyNumericCtr$ Value��� $ mid_rect_tow��$��3��$��1��#��z���� $ PART_Add_Border��$��4��$��40��$
	 Icon��$	
 180��$ 16��$� �M791.457164 482.009422 542.361553 482.009422 542.361553 232.913811c0-17.190122-13.94987-31.139992-31.139992-31.139992-17.190122 0-31.139992 13.94987-31.139992 31.139992l0 249.095611L230.985958 482.009422C213.795836 482.009422 199.845966 495.959292 199.845966 513.149414c0 17.190122 13.94987 31.139992 31.139992 31.139992l249.095611 0 0 249.095611c0 17.224179 13.94987 31.139992 31.139992 31.139992 17.190122 0 31.139992-13.915813 31.139992-31.139992L542.361553 544.289406l249.095611 0c17.224179 0 31.139992-13.94987 31.139992-31.139992C822.597156 495.959292 808.681343 482.009422 791.457164 482.009422L791.457164 482.009422zM791.457164 482.009422��$ 16��#��z�� P� $ PART_Reduce_Border�� � {�$ false��. ��� $ PART_Reduce_Border�� �@J�Opacity$
 0.56Q�P� $ PART_Add_Border�� � {�$ false��. ��� $ PART_Add_Border�� �@J�Opacity$
 0.56Q�P�  �@J�IsMouseOver$
 true���� &"MyNumeric_type_Tow_ControlTemplate "   .R��� $ bg��#��z��#��z��#��z�� ��  �� *TemplatedParent+$$ (My:ElementExten.CornerRadius)�._��  �� �� $
��auto ��� $
��auto �.+�� $��0��#��z��$��Stretch=�#��z��.+��� $ PART_ContentHost��$��Stretch=�$��Center=�#��z��#��z��$ Number��$  ��$��0q�#��z��#��z��$ False�� ��  ��  My:MyNumericCtr$ 
IsReadOnly�����  ��  My:MyNumericCtr$ Value��� $ mid_rect_one��$��1��$��1��#��z��� $��2�� �� �� $
��auto ��� .+��� $ PART_Add_Border��$��40��$
	 Icon��$	
 180��$ 6��$� �M76 326L490.6 740.7c5.7 5.7 13.3 8.79999999 21.4 8.8s15.69999999-3.2 21.4-8.8L948 326c8.6-8.6 11.2-21.59999999 6.5-32.9-4.7-11.3-15.69999999-18.6-27.9-18.6l-829.3 0c-12.2 0-23.2 7.4-27.9 18.6-4.6 11.3-2.1 24.3 6.6 32.9z��$ 13��#��z���� $ mid_rect_Tow��$��1��$��1��#��z���� $ PART_Reduce_Border��$��2��$��40��$
	 Icon��$
 0��$ 6��$� �M76 326L490.6 740.7c5.7 5.7 13.3 8.79999999 21.4 8.8s15.69999999-3.2 21.4-8.8L948 326c8.6-8.6 11.2-21.59999999 6.5-32.9-4.7-11.3-15.69999999-18.6-27.9-18.6l-829.3 0c-12.2 0-23.2 7.4-27.9 18.6-4.6 11.3-2.1 24.3 6.6 32.9z��$ 13��#��z�� P� $ PART_Reduce_Border�� � {�$ false��. ��� $ PART_Reduce_Border�� �@J�Opacity$
 0.56Q�P� $ PART_Add_Border�� � {�$ false��. ��� $ PART_Add_Border�� �@J�Opacity$
 0.56Q�P�  �@J�IsMouseOver$
 true�� P�  �@ TextBoxType$ Numeric_Type_One��. ���  � ��$ Center=���  � ��$ Center=���  � ��$ 32����  �@J�Opacity$ 1Q���  � ��$	 3,0q���  � ��# �  ��  � ��# �  ��  �@ CornerRadius$ 4����  � ��# �  ��  � ��$ 1q���  � ��# �  P�  �@ TextBoxType$ Numeric_Type_Tow��. ���  � ��$ Center=���  � ��$ Center=���  � ��$ 32����  �@J�Opacity$ 1Q���  � ��$	 3,0q���  � ��# �  ��  � ��# �  ��  �@ CornerRadius$ 4����  � ��# �  ��  � ��$ 1q���  � ��# �  P�  � {�$ False��. ���  �@J�Opacity$
 0.76Q��� 8   "    