   M S B A M L   `   `   `  ����J  FXH.SmartParking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:XH.SmartParking.Views.Pages.Dialogs#XH.SmartParking.Views.Pages.Dialogs  5      Q-clr-namespace:XH.SmartParking.Base.ConvertersXH.SmartParking.Base.Converters  5      8    2XH.SmartParking.Views.Pages.Dialogs.ModifyUserView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:XH.SmartParking.Views.Pages.Dialogs     5      ;c-clr-namespace:XH.SmartParking.Base.Converters     5         DialogViewTemplate#��[  5      $	��350��5	   7   $	��500��6D   .��5      � $��1��6   $��20,10q�6     +� FocusedElement  6'   ��  �� ElementName$ tb_un�� � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $��60 �6   �� 5      .+�5   
   �� $��	用户名��6   $��Center=�6   ���#8886:   �� 5   
   $��	姓   名��6   $��1��6!   $��Center=�6.   ���#8886I   �� 5   
   $��	性   别��6   $��2��6!   $��Center=�6.   ���#8886I   �� 5   
   $��	地   址��6   $��3��6!   $��Center=�6.   ���#8886I   �� 5   
   $��	年   龄��6   $��4��6!   $��Center=�6.   ���#8886I   �� 5    
   $��	手机号��6   $��5��6   $��Center=�6,   ���#8886G   �� 5$   
   -   5        $��tb_un��5$   "   $��1��6   $��30��6/     ValidationTextBoxStyle#��[ 5&      ��5%      �� *UserInfo.UserName+" �� ValidatesOnNotifyDataErrors$
 True�� �� 
IsReadOnly 5'      �� *IsReadOnlyUserName+�� 5(   
   $��1��6   $��1��6"   $��30��6/     NormalTextBoxStyle#��[ 5*      ��5)      �� *UserInfo.RealName+5*      �� 5+   
    �� Orientation$ 
Horizontal=�6   $��2��6.   $��1��6;   $��Center=�5,      .+�51      	� $	��男��6    d� 	IsChecked 52      �� *Man+ �� Mode$ TwoWay=�	� 53      $	��女��6   $
��10,0q�6&    54      �� *Woman+$ TwoWay=�55      �� 56   
   $��1��6   $��3��6D   #��[ 57      $��2��6>   $��30��58      ��56   "   �� *UserInfo.Address+58      �� 59   
   $��1��6   $��4��6@   #��[ 5:      $��2��6B   $��30��5;      ��59   "   �� *UserInfo.Age+5;      �� 5<   
   $��1��6   $��5��6B   #��[ 5=      $��2��6>   $��30��5>      ��5<   "   �� *UserInfo.Phone+5>      5@      5A      