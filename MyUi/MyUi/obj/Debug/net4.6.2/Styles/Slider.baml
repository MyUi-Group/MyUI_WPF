   M S B A M L   `   `   `  ����?  ;MyUi, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MyUi.ControlsMyUi.Controls  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   RepeatButtonTransparent  �� 
TargetType �� Property �� Value �� RelativeSource �� AncestorType �� Path �� 
TargetType " RepeatButtonTransparenVertical   SliderThumbHorizontalDefault � UseLayoutRounding � RowDefinitions	 A�Name  CalendarItemButtonSelect
 J� Opacity �� Triggers P� Property P� Value N� EnterActions �� 
TargetName �� TargetProperty	 W� To g� Duration N� ExitActions �� 
TargetName  Common_DisabledColor_Second  SliderHorizontal    MyUi.Controls.MySlider ��Name �� Padding J� SnapsToDevicePixels � ColumnDefinitions  
Main_Color  CommonBorder_Color �� CornerRadius ]�Name ]� DecreaseRepeatButton �� DecreaseLarge ]� IncreaseRepeatButton �� IncreaseLarge ]� Thumb  n�Name! � Cursor" � OverridesDefaultStyle  SliderVertical# m�Name$ m� Fill% m� 	Placement 	 MySlider_Style    MyUi.Controls.ElementExten& �� Triggers' �� BasedOn�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      "Myclr-namespace:MyUi.Controls  5      .sys&clr-namespace:System;assembly=mscorlib  5      %I  &	        &	 �    &	     &	 '    7   7   7  &	 [    7  7  7  &		 k    7  7  '   �    7 	 �� 5
      "  ��6,   .�5   
   ��  �@�OverridesDefaultStyle$
 true��62   �� 5   
    � |�$ false��6&   �� 5   
    � ��$ false��6&   �� 5   
    � �� 6#   ��  ��  My:MySlider$ 
SliderSize��� 5   
    � �� 5      �� 5      " ��6"   .R�5      �� #��z��5      #��z��5      #��z��5      5      5      5      �� 5      "  ��63   .�5   
   ��  �@�OverridesDefaultStyle$
 true��62   �� 5   
    � |�$ false��6&   �� 5   
    � ��$ false��6&   �� 5    
    � �� 6"   ��  ��  My:MySlider$ 
SliderSize��� 5!   
    � �� 5"      �� 5#      " ��6"   .R�5$      �� #��z��5%      #��z��5&      #��z��5'      5(      5*      5+      �� 5-      " n�6;   .R�5.   
   � $��Center=�5/      $��Center=�50      $
 True��51       52      �� 53      $
��auto �6    �� 54      $
��auto �6    .+�57      A� $	 shadow��58      $��1��59      $��25��5:      $��25��5;      $	��-12q�5<      #���  5=      $
 .0Q�5>      A� 5?      $
	 grip��5@      $��1��5A      $��13��5B      $��13��5C      #���  5D      5E       5F   
   P� 5G       �@J�IsMouseOver$
 true��6-    5H      �� 5I      .��5J      �� .��5K      W� $ shadow��5L   !   $ Opacity�5M   !    .265N   !   $ 0:0:0.2D�5O   !   5P      5Q       5S      �� 5T      .��5U      �� .��5V      W� $ shadow��5W   !   $ Opacity�5X   !    .05Y   !   $ 0:0:0.2D�5Z   !   5[      5\      5^      P� 5_       �@n�
IsDragging$
 true��6,   P� 5`       � {�$ false��6+   . �5a      �� $
 grip��6   # �  6;    � ���� 5b      $
 grip��6   # �  6=    � ��5c      5e      �� 5j      "   6/   .R�5k   
   �� $ border��5l      # z��5m      $��Center=�5n      #��z��5o      #��z��5p      #��z��5q      $
 True��5r      ._�5s      �  5t      �� 5u      $��* �6'   �� 5v      $
��auto �6'   .+�5x      � $��0��6    5y      �� 5z      $
��Auto �6(   �� 5{      $
��Auto �6(   #��z��66   �� 5|      $
��Auto �6(   .+�5      �� $ TrackBackground��5�      $��1��5�      $��center=�5�      #���  5�      #���  5�      $��1q�5�      ��5�      ��  ��  My:MySlider$ 
SliderSize� 5�      ��  �� 
 Slider$$ (My:ElementExten.CornerRadius)�]� 5�      $ 
PART_Track��6   $��1��60    5�      �� 5�      #��Z 6+   8��  6U    5�      �� 5�      ���#FFFFFF#��Z 5�   !   $	
 0.6Q�5�   !   8�� 5�   !    5�      n� 5�      $  
PART_Thumb��5�   !   $
��Left=�5�   !   $��Center=�5�   !   $
! Hand��5�   !   $|�False��5�   !   $
" True��5�   !   8�� 5�   !   5�      5�      5�      5�      5�      �� 5�      "   6-   .R�5�   
   �� $ border��5�      #��z��5�      #��z��5�      #��z��5�      $
 True��5�      ._�5�      �  5�      �� 5�      $
��Auto �6'   �� 5�      $
��Auto �6'   #��z��64   �� 5�      $
��Auto �6'   .+�5�      �� $ TrackBackground��5�      $��1��5�      $��center=�5�      #���  5�      #���  5�      $��1q�5�      ��5�      ��  ��  My:MySlider$ 
SliderSize� 5�      ��  �� 
 Slider$$ (My:ElementExten.CornerRadius)�]� 5�      $ 
PART_Track��6   $��1��6,    5�      �� 5�      #��Z 6'   8��  6Q    5�      �� 5�      ���#FFFFFF#��Z 5�      $	
 0.6Q�5�      8�� 5�       5�      n� 5�      $  Thumb��5�      $	��Top=�5�      $|�False��5�      $
" True��5�      8�� 5�      5�      m� 5�      $# 
BottomTick��5�      $��2��5�      $��4��5�      $��2,0,0,0q�5�      #$ z��5�      $% Right=�5�      $y�	Collapsed=�5�      5�      5�      5�      �� 5�      "    6#   .�5�   
   ��  �@ CornerRadius$ 5��69   �� 5�   
    � ��
 ���� 6'   �� 5�   
    � ��
 ���� 6(   �� 5�   
    � ��$ Center=�6.   �� 5�   
    � ��8   6%   & 5�   
   P� 5�       �@��Orientation$ Vertical=�6-   . �5�      ��  � ��8  6-   5�      5�      �� 5�      8'   "    66   5�      