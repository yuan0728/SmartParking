   M S B A M L   `   `   `  ����W  SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   DisabledBrush  �� Color  DropDownButtonTemplate �� 
TargetType 	 Icons �� Triggers P� Property P� Value �� 
TargetName  TextBox.MouseOver.Border �� Value �� Property  TextBox.Focus.Border(   "System.Windows.Controls.DatePicker �� 
TargetType  TextBox.Static.Border	 �� CornerRadius
 �� Padding'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard g� Duration	 W� To �� TargetProperty �� 
TargetName �Name � ColumnDefinitions ��Name:  4System.Windows.Controls.Primitives.DatePickerTextBox  Name �� 
IsReadOnly J� IsHitTestVisible J� Opacity �� RadiusY �� RadiusX �Name � AllowsTransparency � 	StaysOpen � PlacementTarget �� ElementName  �� Value! �� Binding" �� Source# �� RelativeSource�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %�	  &	        &	 #     7  7  '   ;    7  7  �� 5      $  	#A5FFFFFF��6,   �� 5      " ��65   .R�5   
   �� $
��back��6*   
������ ._�5      �� $	����6   #���  6(   $��Center=�6M   $��Center=�6h   $��16(�6�   5	       5
   
   P� 5       �@J�IsMouseOver$
 true��6-   . �5      �� $
 back��60   8    � ��6B   5      P� 5       �@J�IsKeyboardFocused$
 true��63   . �5      �� $
 back��60   8   � ��6B   5      P� 5       �@J�IsMouseOver$
 True��6-   . �5      �� $
 back��6    � �� �#EEE6A   5      5      �� 5      "   6   .�5   
   ��  � �� �	#FF3333336'   �� 5   
    �@  IsTodayHighlighted$
 True��6/   �� 5   
    �@  SelectedDateFormat$ Short=�6/   �� 5   
    � ��
 ���� 6'   �� 5   
    � ��8   6(   �� 5   
    � ��$ 2q�6$   �� 5   
    � ��$ 1q�6,   �� 5    
    � ��$ Stretch=�67   �� 5!   
    � ��$ Center=�65   �� 5"   
    � �� 5#      �� 5$      "   6"   .R�5%      �� #��z��6   #��z��5&      
�������$	 5��5'   0   #
 z��5(       5)        5*      CommonStates��. 5+   "     
Normal��6.     5,   "   Disabled��. 5-   &   �� .��5.   *   W� $ 0D�6:    16G   $ Opacity�6N   $ PART_DisabledVisual��6r   5/   '   50   #   51      ._�53      � $ 	PART_Root��6   #��z��62   #��z��54       55      �� 56   "   $��* �63   �� 57   "   $
��Auto �63   .+�59      �� $ PART_Button��6%   $��1��6:   #��z��6J   $|�False��6t   8�� $��20��5:   X     5<      $ PART_TextBox��60   $��0��6F   #|�z|�6V   $��Stretch=�6~   $��0��6�   $��Stretch=�6�   $
 True��5=   0   � 5>      $ PART_DisabledVisual��6#   $��2��6@   $��0��6T   $ False��6d   $ 0Q�6}   $��0��6�    5?   "   �� 5@   &   $��* �67   �� 5A   &   $
��Auto �67   .+�5C   "   �� $��0��6,   ���	#A5FFFFFF$ 1��6M   $��0��6Y   $ 1��6f   �� 5D   "   $��1��6,   ���	#A5FFFFFF$��18��6M   $��3,0,3,0q�6Y   $ 1��6j   $��0��6v   $ 1��6�   $��19��6�   � 5E   "   $ 
PART_Popup��6(   $
 True��6<   $��Bottom=�6V   $ False��6�    6i   �� $ PART_TextBox��6�   5F      5G      5H       5I      �� 5J      $  false��6j   ! 6&   �� #" Zr�.a�5K      �� $ PART_TextBox��6;    6U   �� *
Foreground+# �� *TemplatedParent+ � ��5L      5N      5P      5Q      5S      