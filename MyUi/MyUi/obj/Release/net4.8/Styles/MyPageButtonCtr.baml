   M S B A M L   `   `   `  ���� ?  ;MyUi, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MyUi.ControlsMyUi.Controls  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   PaginationButtonStyle  �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius ��Name J� SnapsToDevicePixels � UseLayoutRounding	 �� Triggers
 P� Property P� Value  
Main_Color  Common_Color  MyPageButton#    MyUi.Controls.MyPageButtonCtr � ColumnDefinitions  Comon_Font_Color_Second �� RelativeSource �� AncestorType �� Path �� Mode �� UpdateSourceTrigger ��Name � Cursor H� Drawing I� ClipGeometry �� Rect � Brush � Geometry B� FillRule �� 
TargetName  Common_Bg_Color ��Name �� Orientation � 	Resources �� BasedOn ��Name    MyUi.Controls.ElementExten    TextBoxType!   	Watermark" �� IsInputMethodEnabled# ��Name$ �� SelectedIndex  MyComboBoxStyle% �� SelectedValue�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     "Myclr-namespace:MyUi.Controls  %%  &	        &	 �    7   '   �    7  �� "  	�.���  � ��$ 32����  � ��$ 32����  �@�Cursor$
 Hand����  � ��$ Center=���  � ��$ Center=���  � �� �� " 	�.R��� $ 
BorderRoot��#��z��#��z��#��z��$ 4��._��� $ contentPresenter��#��z��#��z��#��z��$
��True��# z $
 True��	 P� 
 �@d�	IsChecked$
 TrueY�. ��� # �   � ���� # �   � ����  � {�$ False���� "    .���  � �� �#CACACA��  � �� �#DDDDDD��  � ��$ 14(���  � �� �� "   .R��  �� $
��auto ��� �� $
��auto ��� $
��auto �.+��� $��Center=�$��Center=�#���  �� $
�共 �� �� ���  ��  My:MyPageButtonCtr$ DateSum�$ TwoWay=�$ PropertyChanged=� �� $
� 条��� $��1��$��20,0,0,0q� �� $
��auto ��� �� $
��auto �.+��� $ PerviewButton��$��32��$��32��$��0,0,10,0q�#��z��#��z��$
 Hand������  ��  My:MyPageButtonCtr$ BorderBrush�����  ��  My:MyPageButtonCtr$ 
Foreground���Z� ���� " ��.R��� $ Border_PrevButton��#��z��#��z��$ 4������  ��  My:MyPageButtonCtr$ BorderBrush�._��� $��12��$��8����H�  I�  �� $ 0,0,8,13�.���  �#4D4D4D B� $z��tM6.57583,0.576172L7.35986,1.36866 2.20793,6.57617 7.35986,11.7837 6.57583,12.5762 0.639864,6.57617 6.57583,0.576172zC�$ EvenOdd=�	 P� 
 � {�$ False��. ��� $ Border_PrevButton�� �@J�Opacity$	 0.6Q��� $ Border_PrevButton��# �   � ��P� 
 � {�$
 True��. ��� $ Border_PrevButton�� �@J�Opacity$ 1Q��� $ Border_PrevButton��# �   � ���� $ Border_PrevButton�� � ��$ 1q��� $ ButtonContaNerPanel��$��1��$��Center=�$ 
Horizontal=� ���� 8   '	�       "  	�.���  � ��$ 4,0,0,0q���  � �� ��  ��  My:MyPageButtonCtr$ BorderBrush��� $ 
NextButton��$��2��$��32��$��32��$��10,0,0,0q�#��z��#��z��$
 Hand������  ��  My:MyPageButtonCtr$ 
Foreground���Z� ���� " ��.R��� $ Border_NextButton��#��z��#��z��$ 4������  ��  My:MyPageButtonCtr$ BorderBrush�._��� $��12��$��8����H�  I�  �� $ 0,0,8,13�.���  �	#FF4D4D4D B� ${��uM1.42418,0.576172L0.640145,1.36866 5.79208,6.57617 0.640144,11.7837 1.42418,12.5762 7.36014,6.57617 1.42418,0.576172zC�$ EvenOdd=�	 P� 
 � {�$ False��. ��� $ Border_NextButton�� �@J�Opacity$	 0.6Q��� $ Border_NextButton��# �   � ��P� 
 � {�$
 True��. ��� $ Border_NextButton�� �@J�Opacity$ 1Q��� $ Border_NextButton��# �   � ���� $ Border_NextButton�� � ��$ 1q�� $��2��$��10,0,0,0q� �� �� �� .+��� $��Center=�$��Center=�#���  $��	前往第���� $ GoPageTextBox��$��1��$��32��$��32��$��10,0,0,0q�$��Center=�$��Center=�$  Number��$!  ��$��1q�#���  $" False������  ��  My:MyPageButtonCtr$ BorderBrush�����  ��  My:MyPageButtonCtr$ CurrentPage�$ TwoWay=�$ PropertyChanged=��� $��2��$��10,0,0,0q�$��Center=�$��Center=�#���  $	��页��� $��3��$��	10,0,10,0q�.+��� $# Limit_ComBox��$	��100��$��32��$$ 0��#���  ����  ��  My:MyPageButtonCtr$ Limits�$ TwoWay=�$ PropertyChanged=�% ��  ��  My:MyPageButtonCtr$ EveryPageShowNum�$ TwoWay=�$ PropertyChanged=����� .R��� $��Center=�$��Center=��� ��� *.+ �� $�条/页���� 8   "    