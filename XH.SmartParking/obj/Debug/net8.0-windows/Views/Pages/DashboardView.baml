   M S B A M L   `   `   `  ����J  FXH.SmartParking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:XH.SmartParking.Views.PagesXH.SmartParking.Views.Pages  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      S OXH.SmartParking.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulleHclr-namespace:XH.SmartParking.Controls;assembly=XH.SmartParking.ControlsXH.SmartParking.Controls 5      /    )XH.SmartParking.Views.Pages.DashboardView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:XH.SmartParking.Views.Pages     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      XxhcHclr-namespace:XH.SmartParking.Controls;assembly=XH.SmartParking.Controls     5        � 	Resources  5       �� 
TargetType   TopTabButtonStyle �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value  LastMonthButtonTemplate �� CornerRadius	 �� RelativeSource
 �� AncestorType �� Mode �� Triggers �� 
TargetName��%�  &	        &	 �    �� 5   
   " 	�6   .�5      ��  � ��$ 33��6'   �� 5       � �� �#5556+   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " 	�6&   .R�5      � 
������ .+�5      �� $��Center=�6/   #��z��5      5      5      5       5      P� 5       �@d�	IsChecked$
 TrueY�6/   . �5      ��  � ��$
 Bold"�63   5      5      �� 5!   
   " ��6   .R�5"      �� $
��back��6;   ���#f8f8f8$ 8��6*   ._�5#      �� $	��txt��5%   &   $��Center=�5$      $��Center=�67   $
��10,4q�5%      ��5#      �� *	Content+	 �� 
 CheckBox$ FindAncestor=�5%   &   5&       5'      P� 5(       �@d�	IsChecked$
 TrueY�6/   . �5)      �� $
 back��6E    � �� �	#FFF05005�� 5*      $	 txt��6K    � ��
 �����5+      5-      5.      .��5/      �� .��50   
   �  � RowDefinitions 51      �� 52      $
��auto �6    �� 53      $
��auto �6    �� 54      $	��370 �6    �� 55      $
��auto �6    .+�58      �� $	��150��6   $
��Left=�6!   ���#EEE$��0,0,0,1q�6O   $
��10,0q�6i   ._�59      A�  A� Rows$ 1��6   .+�5:      	� $��今天��6"   #��[  6/    d� 	IsChecked$
 TrueY�6Z   $
��Left=�6k   	� 5;      $��本周��6"   #��[  6/   $��Center=�6Z   	� 5<      $��本月��6"   #��[  6/   $��Right=�6Z   5=      5>      �� 5?      $��Center=�6   $��Right=�64    �� Orientation$ 
Horizontal=�6P   $
��10,0q�6i   .+�5@      �� $	��130��6   $��30��6'    �� 
IsEditable$ False��63    �� SelectedIndex$ 0��6g   $
��20,0q�5A   <    �� DisplayMemberPath$ AreaName��6J   ��5@   F   �� *
AreaList+ �� SelectedItem 5A      �� *CurrentArea+5B      (  "System.Windows.Controls.DatePicker  5C      $	��130��6   $��30��6)   $��0q�65      SelectedDate 6I   �� *CurrentDate+5D      �� 5F      $��1��6   ��6(   �� *	BoardList+��5G      �� 5H      .R�5I      A� $ 1��6&   5J      ��5L      �� 5M      .R�5N      �� $ 5��6!   ���#FAFCFF$��10q�6G    J� Effect 5O      3  -System.Windows.Media.Effects.DropShadowEffect  5P   "      
BlurRadius$ 10Q�63      ShadowDepth$ 0Q�6C      Color$
 #555��6S      Opacity$	 0.1Q�6`   ._�5R      �� $��30,10q�6)   .+�5S   "   �� ���#AAA$��0,10,0,5q�6>   $��12(�6P   �� 5T   "    	 Icons#��[ 6<   $��15(�6}   �6&   �� *Icon+��6`   �� *Color+6}    �� 5U   "   �6&   �� *Header+5V   #   �� 5X   "   $��22(�6Y   $��Normal"�6g   ���#555��6,   �� *Value+ �� StringFormat$ {0:N0}��6{   � 5Z   "   $��0,5,0,10q�6'   $��11(�69   .+�5[   &   �� $
��Left=�60   
��� � ��� 5\   *   $	���6.   #��[ 6>    �� 5]   *   $	�+5%��6.   5^   '   �� 5_   &   $��Right=�60   ���#888�� 5`   *    �� TextDecorations$
 None{�64   .�6K   详情6O   5a   '   5b   #   5c      5d      5e      5g      � 5j      $��2��6    � ColumnDefinitions 5k      �� 5l      $��3* �6'   �� 5m      $��2* �6'   .+�5p      �� $ 5��6   ���#FAFCFF$��10q�6?    5q        5r      $ 10Q�6+   $ 0Q�6;      	Direction$ 0Q�6K   $
 #555��6Y   $	 0.1Q�6f   5t      � 5u      ���#FAFCFF$��20q�6,    5v      �� 5w      $��45 �6(   �� 5x      .+�5{      �� ���#EFEFEF$��1��62   $��Bottom=�6=   �� 5|      $��最新进出车辆记录��6    $��14(�60   $��Center=�6>   $
��Left=�6Y   $
��15,0q�5}      $��Normal"�6*   ���#8886>   �� 5~      $ 
Horizontal=�6!   $��Center=�6:   $��Right=�6U   .+�5      �� $��	上个月��6#   #��[ 61   $��8(�6e   ���#888$
 TrueY�6�   �� 5�      $	����6$   #��[ 64   $
��15,0q�6X   
�������6f   5�      �� 5�      $��1��6   
������ $��0q�6D   ��6X   �� *
RecordList+��5�      �� 5�      " ��6$   .�5�   "   ��  � ��$ Stretch=�6O   �� 5�   "    � �� 5�   &   �� 5�   *   " ��6:   .R�5�   .   �� $��border��6N   
������ ._�5�   2   �� 5�   /    5�   .   P� 5�   2    �@J�IsMouseOver$
 True��6Q   . �5�   6   �� $ border��6=    � �� �#F0F6FB6g   5�   3   5�   +   5�   #   5�      ��5�      �� 5�      .R�5�   "   �� ���#EFEFEF$��0,0,0,1q�6?   ._�5�   &   � $��10,15q�6+    5�   *   �� 5�   .   $
��auto �6?   �� 5�   .   .+�5�   *   �� $	��130��61   $��75��6=   $ 5��6I   ��5�   .   �� 5�   2     �� ImageSource  6=   �� *
CarImage+5�   +   �� 5�   *   $��1��65   $��Center=�6E   $
��15,0q�6`   .+�5�   .   �� ���#444$��Normal"�6b   ��68   �� *Number+6b   �� 5�   .   ���#AAA$
��0,10q�6f   $��10(�6t   ��68   �� *
RecordInfo+6t   �� 5�   .   $��10(�68   �� 5�   2   $�停车场：��66   ���#AAA6B    �� 5�   2   $�武汉人信汇停车场��66   $��Normal"�6F   ���#4446Z   5�   /   5�   +   5�   '   5�   #   5�      5�      5�      � 5�      $��1��6    5�      �� 5�      �� 5�      .+�5�      �� $ 5��6   
�������$��10q�6A    5�        5�      $ 10Q�6/   $ 0Q�6?   $ 0Q�6O   $
 #555��6]   $	 0.1Q�6j   ._�5�      � $��20q�6    5�      �� 5�   "   $��28 �60   �� 5�   "   .+�5�      �� $��今日收费汇总��6(   $��Center=�66   ���#5556Q   �� 5�      $	����6(   #��[ 68   $��Center=�6\   $��Right=�6w     LiveCharts.Wpf.PieChart  5�      -   5        $
��pie1��5�   9   $��1��6,   &   LiveCharts.Wpf.Charts.Base.Chart!   LegendLocation$! Right=�6E   "   InnerRadius$" 30Q�6\   $��5q�6m   #   HoverPushOut$# 1Q�6x   $   DataTooltip$ 6�   Z� %   Series% 6�   �� *Series+&   ChartLegend& 5�   "   "  LiveCharts.Wpf.DefaultLegend  5�   &   '   
BulletSize$' 10Q�68   $��10(�6H   $
��30,5q�6V   $	��200��6d   $	��200��6p   5�      5�      5�      A� 5�      $��1��6"   $ 1��6/   .+�5�      � .+�5�      �� 
�������$��
10,10,5,10q�68   $ 5��6L    5�   "     5�   &   $ 10Q�67   $ 0Q�6G   $ 0Q�6W   $
 #555��6e   $	 0.1Q�6r   5�      � 5�      $��20q�6#    5�   "   �� 5�   &   $��28 �64   �� 5�   &   �� 5�   &   $��28 �64   .+�5�   "   �� $��各收费车场排行��6,   $��Center=�6;   ���#5556V   �� 5�   "   $	����6,   #��[ 6<   $��Center=�6`   $��Right=�6{   A� 5�   "   $��1��6.   $ 1��6;   .+�5�   &   �  5�   *   �� 5�   .   �� 5�   .   $��12 �6<   .+�5�   *   �� $��8��61   $ 4��6;   
��� ���$��20��6`   $��Bottom=�6l   �� 5�   *   $��6��61   $��6��6;   $ 3��6F   
��� ���$��1��6k   5�   '   � 5�   &    5�   *   �� 5�   .   �� 5�   .   $��12 �6<   .+�5�   *   �� $��8��61   $ 4��6;   ���	#FF05C882$��40��6c   $��Bottom=�6o   �� 5�   *   $��6��61   $��6��6;   $ 3��6F   ���	#FF05C882$��1��6n   5�   '   � 5�   &    5�   *   �� 5�   .   �� 5�   .   $��12 �6<   .+�5�   *   �� $��8��61   $ 4��6;   ���	#FF05C882$��60��6c   $��Bottom=�6o   �� 5�   *   $��6��61   $��6��6;   $ 3��6F   ���	#FF05C882$��1��6n   5�   '   � 5�   &    5�   *   �� 5�   .   �� 5�   .   $��12 �6<   .+�5�   *   �� $��8��61   $ 4��6;   
��� ���$��30��6`   $��Bottom=�6l   �� 5�   *   $��6��61   $��6��6;   $ 3��6F   
��� ���$��1��6k   5�   '   � 5�   &    5   *   �� 5  .   �� 5  .   $��12 �6<   .+�5  *   �� $��8��61   $ 4��6;   ���	#FF05C882$��50��6c   $��Bottom=�6o   �� 5  *   $��6��61   $��6��6;   $ 3��6F   ���	#FF05C882$��1��6n   5  '   � 5  &    5  *   �� 5	  .   �� 5
  .   $��12 �6<   .+�5  *   �� $��8��61   $ 4��6;   ���	#FF05C882$��20��6c   $��Bottom=�6o   �� 5  *   $��6��61   $��6��6;   $ 3��6F   ���	#FF05C882$��1��6n   5  '   � 5  &    5  *   �� 5  .   �� 5  .   $��12 �6<   .+�5  *   �� $��8��61   $ 4��6;   ���	#FF05C882$��10��6c   $��Bottom=�6o   �� 5  *   $��6��61   $��6��6;   $ 3��6F   ���	#FF05C882$��1��6n   5  '   5  #   �� 5  "   $��各停车场��6,   $��2��68   $��Center=�6E   $��Center=�6`   $��10(�6}   ���#8886�   5     5     � 5     .+�5     �� 
�������$��
5,10,10,10q�68   $ 5��6L    5  "     5  &   $ 10Q�67   $ 0Q�6G   $ 0Q�6W   $
 #555��6e   $	 0.1Q�6r   5!     � 5#     $��20q�6#    5$  "   �� 5%  &   $��28 �64   �� 5&  &   �� 5'  &   $��28 �64   .+�5)  "   �� $��进出车辆统计��6,   $��Center=�6:   ���#5556U   �� 5*  "   $	����6,   #��[ 6<   $��Center=�6`   $��Right=�6{   2  ,XH.SmartParking.Controls.CircularProgressBar  5,  "   $��1��6:   (   Value$( 60Q�6G   )   	ForeColor) �	#FF1E8CFA*   	BackColor* �#EfEfEF$��20q�6|   �� 5-  "   $��2��6,   $��Center=�69   $��Center=�6T   $��10(�6q   �� 5.  "   $
 None{�6,   .�6C   查看详情6I   5/  #   50     51     52     53     55     �� 58     $��3��6   ���#FAFCFF$ 5��67   $��10q�6H    59       5:     $ 10Q�6'   $ 0Q�67   $ 0Q�6G   $
 #555��6U   $	 0.1Q�6b   ._�5<     � $��20q�6   $��3��6#    5=     �� 5>     $��45 �6(   �� 5?     .+�5A     �� ���#EFEFEF$��1��62   $��Bottom=�6=   �� 5B     $��各门岗通行记录��6    $��Center=�6/   $
��10,0q�6J   $��14(�6X   $��Normal"�6f   ���#5556z   &   System.Windows.Controls.DataGrid  5D     $��1��6   $��0,0,0,10q�6M   "+   VerticalScrollBarVisibility$
+ Auto=�5E  '   $,   HorizontalScrollBarVisibility$
, Auto=�6J   ��5D  ,   �� *
InfoList+-   Columns- 5F     0  *System.Windows.Controls.DataGridTextColumn  5G     ,	  &System.Windows.Controls.DataGridColumn. 	  Header$. 日期��61   / 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$/ *
 6=   1  +System.Windows.Controls.DataGridBoundColumn0   Binding0 6G   �� *
PassDate+  5H     $. 通道名称��61   $/ *
 6?   0 6I   �� *
Passageway+  5I     $. 	收费员��61   $/ *
 6>   0 6H   �� *TollCollector+  5J     $. 抬杆状态��61   $/ *
 6?   0 6I   �� *LiftingState+  5K     $. 累计减免��61   $/ *
 6?   0 6I   �� *
DisCount+  5L     $. 使用状态��61   $/ *
 6?   0 6I   �� *State+4  .System.Windows.Controls.DataGridTemplateColumn  5M     $. 操作��65   $	/ 120
 6A   1   CellTemplate1 5N  "   �� 5O  &   .R�5P  *   �� $ 
Horizontal=�65   .+�5Q  .   �� �� 5R  :   $
 None{�6D   2 �� Command2 6[   �� *RecordItemCommand+3 �� CommandParameter3 5S  D   �� .�6a   查看详情6g   5T  /   5U  +   5V  '   5X     5Z     5[     5\     5]     5^     5_     