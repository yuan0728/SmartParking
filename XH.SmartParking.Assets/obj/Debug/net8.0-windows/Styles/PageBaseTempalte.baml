   M S B A M L   `   `   `  ����W  SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType   PageTempalte � RowDefinitions  SearchTextBoxStyle �� UpdateSourceTrigger J� InputBindings
 �� Key �� Command �� Orientation  NormalButtonStyle  IconWithContentButtonStyle
 � Tag �� 
StartPoint	 �� EndPoint
 � Color � Offset �� CornerRadius J� Effect3    -System.Windows.Media.Effects.DropShadowEffect    
BlurRadius    Color    ShadowDepth    Opacity  DialogViewTemplate�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %b  &	        7  7  7  &	 %    7  �� 5      "  >�6   .R�5   
   � $
��10,5q�6    5      �� 5      $��45 �6    �� 5      .+�5
      �� $��	tb_search��5   B   $��Center=�5
      $	��300��61   $
��Left=�6=   8��  ��5      �� *	SearchKey+$ PropertyChanged=�.��5   S    5      �� 5      $ Return��6!    6.   �� *RefreshCommand+.��5   )   5      �� 5      $ 
Horizontal=�6   $��Center=�62   $��Right=�6M   .+�5      �� $��刷新��6   8�� $��60��5      $	��5,0q�6$   ��5      �� *RefreshCommand+5   $   �� 5      $��新建��6   8�� $	 ��5      $��80��6(   ��5      �� *ModifyCommand+��5      �� 5      $	 0,0&�6.   $		 1,0&�6?   .��5      � $
 #FE582D��6+   $ 0Q�6;   � 5      $
 #F1961A��6+   $ 1Q�6;   5      5!      5"      �� 5&      $ 5��6   
�������$��1��69   $��0,5,0,10q�6F    5'         5(      $ 5Q�6'   $
 Gray��66   $ 0Q�6C   $	 0.3Q�6S   5*      �� 5-      $��1��6   5.      5/      �� 51      "  >�6   .R�52   
   �  53      �� 54      $��40 �6    �� 55      �� 56      $��40 �6    .+�58      �� ���#FAFCFF$��1��6*   �� 59      $��1��6   ���#EEE$��Bottom=�62   �� 5:      $��1��6   $��2��6    ���#EEE$	��Top=�6?   �� 5<      $��14(�6/   $��Center=�5=      $
��Bold"�5>      ���#888$
��10,0q�5?   +   ��5<      �� *Title+5?   +   �� 5A      $��保存��6   $��2��6"   $��30��6/   $	��100��6;   $��Center=�5B      
�������8��  ��5D      �� *SaveCommand+��5E      �� 5F      $	 0,0&�6*   $		 1,0&�6;   .��5G      � $
 #FE582D��6'   $ 0Q�67   � 5H      $
 #F1961A��6'   $ 1Q�67   5I      5K      �� 5N      $��1��6   5O      5P      5Q      