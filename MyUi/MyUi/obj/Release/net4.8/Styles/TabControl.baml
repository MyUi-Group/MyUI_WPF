   M S B A M L   `   `   `  ���� ?  ;MyUi, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MyUi.ControlsMyUi.Controls  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   MyTabItemStyle  �� 
TargetType �� Property �� Value �� Triggers �� Binding �� RelativeSource �� AncestorType �� Path �� Value	 �� 
TargetType
 � Cursor ��Name ��Name J� IsHitTestVisible J� Opacity �� ElementName �� Triggers P� Property P� Value �� 
TargetName  CalendarItemButtonSelect ��Name  CommonBorder_Color  MyTabControlStyle  Common_Color �Name-   'System.Windows.Input.KeyboardNavigation    TabNavigation J� SnapsToDevicePixels � ColumnDefinitions ��Name � RowDefinitions ��Name A�Name K� ZIndex K� IsItemsHost    TabIndex     DirectionalNavigation  Common_DisabledColor! �� BasedOn�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     "Myclr-namespace:MyUi.Controls  %  &	        &	 t    '�� �    7  �� "  ��.���  � ��$
 15,5q���  � ��$ 32����  � ��$ Center=���  � ��$ Center=���  � ��
 ����  ��  ��  �� " ��$+ %(My:MyTabControlExten.TabControlType)� Line.a���  � �� �� "	 ��.R�� #��z��$

 Hand��.+��� $ contentPresenter��#��z��#��z��#��z��$��Header��#��z���� $ 	rectangle��$ False��$ 0Q����� $ contentPresenter��$ (TextBlock.Foreground)� P�  �@��
IsSelected$
 true��. ��� $ 	rectangle�� �@J�Opacity$ 1Q��� $ contentPresenter��# �   � ��P�  �@��
IsSelected$ false��. ��� $ 	rectangle�� �@J�Opacity$ 0Q�P�  �@��TabStripPlacement$
 Left=�. ��� $ 	rectangle�� � ��$ 2���� $ 	rectangle�� � ��$
 auto���� $ 	rectangle�� � ��$ 0,0,-1,0q��� $ 	rectangle�� � ��$ Right=��� $ 	rectangle�� � ��$ Stretch=�P�  �@��TabStripPlacement$	 Top=�. ��� $ 	rectangle�� � ��$
 auto���� $ 	rectangle�� � ��$ 2���� $ 	rectangle�� � ��$ 0,0,0,-1q��� $ 	rectangle�� � ��$ Stretch=��� $ 	rectangle�� � ��$ Bottom=�P�  �@��TabStripPlacement$ Right=�. ��� $ 	rectangle�� � ��$ 2���� $ 	rectangle�� � ��$
 auto���� $ 	rectangle�� � ��$ -1,0,0,0q��� $ 	rectangle�� � ��$
 Left=��� $ 	rectangle�� � ��$ Stretch=�P�  �@��TabStripPlacement$ Bottom=�. ��� $ 	rectangle�� � ��$
 auto���� $ 	rectangle�� � ��$ 2���� $ 	rectangle�� � ��$ 0,-1,0,0q��� $ 	rectangle�� � ��$ Stretch=��� $ 	rectangle�� � ��$	 Top=���  ��  �� " ��$+ %(My:MyTabControlExten.TabControlType)� Card.a���  � �� �� "	 ��.R�� #��z��$

 Hand��.+��� $ border��$��0q�#��z��#���  $��1,1,1,0q�$ 0Q��� $ bordercover��$��10��$y�	Collapsed=�����  ��  
TabControl$ 
Background��� $ contentPresenter��#��z��#��z��#��z��$��Header��#��z�� P�  �@��
IsSelected$
 true��. ��� $ border�� �@J�Opacity$ 1Q��� $ bordercover�� � y�$ Visible=�P�  �@��TabStripPlacement$
 Left=�. ��� $ bordercover�� � ��$ 1���� $ bordercover�� � ��$
 auto���� $ bordercover�� � ��$ 0,1,-1,1q��� $ bordercover�� � ��$ Right=��� $ bordercover�� � ��$ Stretch=��� $ border�� � ��$ 1,1,0,1q��� $ border�� � ��$ 0,0,0,0q�P�  �@��TabStripPlacement$	 Top=�. ��� $ bordercover�� � ��$
 auto���� $ bordercover�� � ��$ 1,0,1,-5q��� $ bordercover�� � ��$ Stretch=��� $ bordercover�� � ��$ Bottom=��� $ border�� � ��$ 1,1,1,0q��� $ border�� � ��$ 0,0,0,0q�P�  �@��TabStripPlacement$ Right=�. ��� $ bordercover�� � ��$ 1���� $ bordercover�� � ��$
 auto���� $ bordercover�� � ��$ -1,1,0,1q��� $ bordercover�� � ��$
 Left=��� $ bordercover�� � ��$ Stretch=��� $ border�� � ��$ 0,1,1,1q��� $ border�� � ��$ 0,0,0,0q�P�  �@��TabStripPlacement$ Bottom=�. ��� $ bordercover�� � ��$
 auto���� $ bordercover�� � ��$ 1,-5,1,0q��� $ bordercover�� � ��$ Stretch=��� $ bordercover�� � ��$	 Top=��� $ border�� � ��$ 1,0,1,1q��� $ border�� � ��$ 0,0,0,0q��� "  ��.���  � ��# �  ��  � ��# �  ��  � ��$ 0q���  � ��# �   ��  � �� �� "	 ��.R�� $ ContainerRoot��$
}�true��$ Local=�$
 true�� �� $ ColumnDefinition0���� $ ColumnDefinition1��$��0 � �� $ RowDefinition0��$
��Auto ��� $ RowDefinition1��$��* �.+�A� $ headerContainerPanel��$��0��$��0��$
��Left=�$ 1��
������ $
 true��$ 1���� $ contentPanel��$��1��$��0��#��z��#��z��#��z��$  	Contained=�$ 2��$ Local=�._��� #��z��$��SelectedContent��# z  P�  �@��TabStripPlacement$	 Top=�. ��� $ headerContainerPanel�� �@A�Rows$ 1��P�  �@��TabStripPlacement$ Bottom=�. ��� $ headerContainerPanel�� �@A�Rows$ 1���� $ headerContainerPanel�� � ��$ 1���� $ contentPanel�� � ��$ 0���� $ RowDefinition0�� � ��$ * ��� $ RowDefinition1�� � ��$
 Auto ��� $ headerContainerPanel�� � ��$ 0q�P�  �@��TabStripPlacement$
 Left=�. ��� $ headerContainerPanel�� � ��$	 Top=��� $ headerContainerPanel�� �@A�Columns$ 1���� $ headerContainerPanel�� � ��$ 0���� $ contentPanel�� � ��$ 0���� $ headerContainerPanel�� � ��$ 0���� $ contentPanel�� � ��$ 1���� $ ColumnDefinition0�� � ��$
 Auto ��� $ ColumnDefinition1�� � ��$ * ��� $ RowDefinition0�� � ��$ * ��� $ RowDefinition1�� � ��$ 0 ��� $ headerContainerPanel�� � ��$ 0q�P�  �@��TabStripPlacement$ Right=�. ��� $ headerContainerPanel�� � ��$	 Top=��� $ headerContainerPanel�� �@A�Columns$ 1���� $ headerContainerPanel�� � ��$ 0���� $ contentPanel�� � ��$ 0���� $ headerContainerPanel�� � ��$ 1���� $ contentPanel�� � ��$ 0���� $ ColumnDefinition0�� � ��$ * ��� $ ColumnDefinition1�� � ��$
 Auto ��� $ RowDefinition0�� � ��$ * ��� $ RowDefinition1�� � ��$ 0 ��� $ headerContainerPanel�� � ��$ 0q�P�  � {�$ false��. ��� $ ContainerRoot��# �   � ���� 8!   "  ��