   M S B A M L   `   `   `  ����?  ;MyUi, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MyUi.ControlsMyUi.Controls  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   MyPasswordBoxStyle  �� 
TargetType �� Property �� Value  Common_Color  CommonBorder_Color  Comon_Font_Color     MyUi.Controls.ElementExten   MyUi.Controls.InputExten-  'System.Windows.Input.KeyboardNavigation �� 
TargetType ��Name J� SnapsToDevicePixels �� CornerRadius �� RelativeSource �� Path	 � ColumnDefinitions
 ��Name J� IsHitTestVisible ��Name �� Padding �� Padding  Warter_Color d�Name
 � Tag �� AncestorType F�Name �� Stretch �� Triggers P� Property P� Value �� 
TargetName �� Value �� Binding �� Mode P� 
SourceName �� Triggers ]� 
Conditions �� Property �� Value!  System.Windows.SystemColors)    "InactiveSelectionHighlightBrushKey! �� BasedOn�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      "Myclr-namespace:MyUi.Controls  5      %)  &	        'G� �    7   �� 5      "  G�6'   .�5   
   ��  �@G�PasswordChar$	 ●��6)   �� 5   
    � ��# �  6'   �� 5   
    � ��# �  6(   �� 5	   
    � ��# �  6'   �� 5
   
    � ��$ 1q�6,   �� 5   
    �@  	Watermark$ 请输入密码��66   �� 5   
    �@ 
IsPassword$
 true��65   �� 5   
    � ��$ 10,0,0,0q�6$   �� 5   
    �@  CornerRadius$ 5��69   �� 5   
    �@ TabNavigation$
 None=�6=   �� 5   
    � ��$
 Left=�67   �� 5   
    � ��$ Center=�65   �� 5   
    �@�FocusVisualStyle 6-   Z� �� 5   
    �@J�	AllowDrop$
 true��6&   �� 5   
    �@��IsInputMethodEnabled$ false��6=   �� 5   
    �@��PanningMode$ VerticalFirst=�65   �� 5   
    �@��IsFlicksEnabled$ False��63   �� 5   
    � �� 5      �� 5      " G�6"   .R�5      �� $ border��5      #��z��5      #��z��5      #��z��5      $
 True��5        5      ��  �� *TemplatedParent+$$ (My:ElementExten.CornerRadius)�._�5!      � 	 5"      �� 5#   "   �� 5$   "   $
��auto �63   .+�5&      �� $
 PART_ContentHost��5'   !   $|�false��5(   !   $��Hidden=�5)   !   $ False��5*   !   $��Hidden=�5+   !   �� 5,      $ ShowPassword_TextBox��5-   !   $ 2,0,0,0q�5.   !   #��z��5/   !   #��z��50   !   #��z��51   !   #��z��52   !   $y�	Collapsed=�53   !   �� 54      $ 2,0,0,0q�55   !   #��z��56   !   #��z��57   !   $ False��58   !   ._�59   "   �� $ 	watermark��5:   %   #��z��5;   %   #��z��5<   %   #��z��5=   %   #���  5>   %   $y�	Collapsed=�5@   %   ��5?   %   ��  �� *TemplatedParent+$! (My:ElementExten.Watermark)�5@   %   5A      d� 5B      $ PART_ToggleButton��5C   !   $��1��5D   !   $��20��5E   !   $��15��5F   !   $
��10,0q�5G   !   $|�False��5H   !   $y�	Collapsed=�5J   !    5I   !   ��  ��  PasswordBox��5K   "   �� 5L   &   " d�66   .R�5M   *   � 
������ .+�5N   .   F� $	 ico��5O   1   ����0s�Z�|� @��~��@v3�� @I>��B@{
�~'� @+��H��@�M?� @4 
��@��G@;� @��*F��@��8 S!@Z
�A�!@�?� �y"��!@�x~�'#@���9"@c"J ��#@Ko$uo"@�� ��́/V"@-� o"DC�!@Q6�� ��@D�!@0��!B3Z�?*3��*?YA���n�?"#i�l?�Z��.�?-���J��?�h��S��?��bT��?��3��?Vh{O@n�?�Q��@~=s E@c5L#A@!ا��@�p�s@d]JY@m�t���@o�@�D YΔ�R� @����̌@)t�%
@�rJ@LZ@'�fjmu
@�nw-��� �32�,� �n2U�� T�-��� ��)�l� 3�!�� G���� �G|� �`׹ �ݘ ��� c�� ӏ�� �̣ �� � �j LP"@�B� �/5B?S @��� ���A�n@�Mz�?�"@�-�2@ �R�F� @:�a�m@���%V~@���?�@��)FL@-���@->��@�漵��@/V] L@�@d�K'�@����@�A ��$3�@�����@W.* 늾'{ @@� *��I  @��!�p}@΢� �b��@Vs� ��� Vs� �SY� Vs� O��  �� ��� G�� �5�� �� ���� #�� Pm� ��� ��� ��� ����E@��� /t��G�@ �� *��I  @<u�&"2�?B�
7@JV�E� @F��Ǝ�@�s�D	@��1 �"zcR]	@~H	
@�ۤ?�;�?������?���!ZҴ�4t`�%T�?���!ZҴ� ��0V�?�ۤ?�;�?Vh{O@n�?X��N�?u�Iᘭ?Ju	�{C�?3���xp���!B3Z�?*3��*?p��� ��6�v�>S�� ��+2A��>٠�{�  @ -1*��I  @S�%%�d�!ף!@ �)��ā�#@���� �4� )ӳ �g� j�� �;l"3c0@��-c��#@S�/���u"@�6e��� @�D*��I  @S�t� ֳ{Mj@�p� ������?��� ������?�,�@3#@������?�<� .
��Q�?@�N��F!@F;?k�?S��q �[!�ƒ @�W*^h@���Oc�?�Tq>�i @�G�T/"�?Sn2� K+��2q�?��_��"@�jP�L�7���� ��6�v�>	
���   �$
 Fill=�5R   1   5S   +    5T   *   P� 5U   .    �@d�	IsChecked$
 trueY�6K   . �5V   2   �� $	 ico��69    � ��� �� ��  ��>;��@  � ��3 @B  	= ��� ��3 ��->;��@ �g5 �� �g5���?��7t@ �g5 	 ��- ��� 	 @B�2H  � ��  �p ��������j@S �X������j@ XUH+�Y@ ����C�l��k@���)����Mbv@��Q0 ����Q0� (�'��Q0/�$�@���) �7������@� ��/U (�'U5� ��U5�� ��UUX� �����(��*,
�*,
� ��UUX��*,
�*,
p ��(%���z@W ��k�}����@UUW ��(%���z@ UU	6Z   5W   /   5Y   '   5[      5\      5]       5^      �� 5_      $  ��6�    6&   ��  �� $
 Self=�$ (My:InputExten.Password)�.a�5`      �� $ 	watermark��6%    � y�$ Visible=�6R   5a      �� 5b       6&   ��  �� $
 Self=�$ (My:InputExten.Password)� 6�   Z� .a�5c      �� $ 	watermark��6%    � y�$ Visible=�6R   5d      P� 5e       � {�$ false��67   . �5f      �� $ border��6%    �@J�Opacity$
 0.56Q�6L   5g      P� 5h      $ PART_ToggleButton��6"    �@d�	IsChecked$
 trueY�6V   . �5i      �� $ PART_ContentHost��6%    � y�$ 	Collapsed=�6Y   �� 5j      $ PART_ContentHost��6%    �@J�IsHitTestVisible$
 true��6_   �� 5k      $ ShowPassword_TextBox��6%    � y�$ Visible=�6]   5l      P� 5m       �@J�IsMouseOver$
 true��69   . �5n      �� $ border��6%    �@J�Opacity$
 0.86Q�6L   5o      P� 5q       �@J�IsKeyboardFocused$
 true��6?   . �5r      �� $ border��6%    �@J�Opacity$
 0.86Q�6L   5s      �� 5u      $ 	Plaintext��6�    6&   ��  �� $
 Self=�$# (My:ElementExten.TextBoxType)�.a�5v      �� $ PART_ToggleButton��6%    � y�$ Visible=�6Z   5w      5y      5{       5|   
   ]� 5}       5~      �� 5      + �@G�#IsInactiveSelectionHighlightEnabled$
 true��6O   �� 5�       �@G�IsSelectionActive$ false��6=   ./�5�      ��  �@G�SelectionBrush# �   63   5�      5�      �� 5�      8!   "  G�6:   5�      