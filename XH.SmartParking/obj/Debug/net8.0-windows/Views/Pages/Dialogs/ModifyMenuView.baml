   M S B A M L   `   `   `  ����J  FXH.SmartParking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:XH.SmartParking.Views.Pages.Dialogs#XH.SmartParking.Views.Pages.Dialogs  5      Q-clr-namespace:XH.SmartParking.Base.ConvertersXH.SmartParking.Base.Converters  5      Q MXH.SmartParking.Assets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullkJclr-namespace:XH.SmartParking.Assets.Fonts;assembly=XH.SmartParking.AssetsXH.SmartParking.Assets.Fonts 5      8    2XH.SmartParking.Views.Pages.Dialogs.ModifyMenuView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:XH.SmartParking.Views.Pages.Dialogs     5      ;c-clr-namespace:XH.SmartParking.Base.Converters     5      XfJclr-namespace:XH.SmartParking.Assets.Fonts;assembly=XH.SmartParking.Assets     5         DialogViewTemplate#��[  5	      $	��350��5
   7   $	��500��6D   .��5      � $��40 20q�6   ���#888  � RowDefinitions  5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $��90 �6   �� 5      .+�5   
   �� $��菜单名称��6   $��Center=�6    �� 5   
   $��	父节点��6   $��1��6   $��Center=�6,   �� 5   
   $��菜单节点类型��6   $��2��6"   $��Center=�6/   �� 5   
   $��目标视图��6   $��3��6    $��Center=�6-   �� 5    
   $��菜单图标��6   $��4��6    $��Center=�6-   �� 5#   
   $��1��6   $��30��6"     NormalTextBoxStyle#��[ 5$      ��5%      �� *MenuModel.MenuHeader+�� 5'   
   $��1��6   $��1��6#   $��30��60    �� DisplayMemberPath$ 
MenuHeader��5)       �� SelectedValuePath$ MenuId��5*      ��5(      �� *ParentNodes+ �� SelectedValue 5+      �� *MenuModel.ParentId+5,      �� 5.   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��2��6>   $��Center=�6K   .+�53      	� $��集合类型��6   ���#888 	� 	GroupName$ group1��6;    d� 	IsChecked 54      �� *MenuTypeList+	� 55      $��视图类型��6   $
��20,0q�6)   ���#888$ group1��6I    56      �� *MenuTypeView+57      �� 58   
   $��3��6   $��1��6   $��30��6/   #��[ 59      ��5:      �� *MenuModel.TargetView+�� 5;   
   $��1��6   $��4��6#   $��2��60   $��65��5<      $	��110��6#   $
��Left=�5=       �� SelectedIndex$ 0��5>        ComboBoxEditableTemplate#��[ 5@      ��5?      �� 	 �� Path$	 (f:IconFonts.All)�
 �� SelectedItem
 5A      �� *MenuModel.MenuIcon+ � 	Resources 5C       �� 
TargetType��%"   '��       �� 5D      " ��6   5E      ��5F      �� 5G      .R�5H      A�  A� Columns$ 8��6"   5I      ��5K      �� 5L      .R�5M      �� $��50��6   $��50��6(   ._�5N      ��  	 Icons#��[ 65   $��Center=�5O   (   $��Center=�6C   $��30(�5P   (   ���#888��5N   $   �� 5P   6   5Q      5R      5T      5U      5V      