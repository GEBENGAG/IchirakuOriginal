   M S B A M L   `   `   `  ����C  ?ichiraku, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ichirakuichiraku  5   	       ichiraku.PaymentWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ichiraku     5   	   $	��450��5   
   $	��800��6   ���#202130  � WindowStartupLocation$  CenterScreen=�68   .��5
      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ tablicaZakaz��5   '   $��3��6      	RowHeight$ 40Q�6=      GridLinesVisibility$ 
Horizontal=�6L   $
��Left=�6n   $	��792��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Количество��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 69   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6C   �� *count+6`     5      $ Наименование��6%   $ * 6;   	 6E   �� *
dishName+6e     5      $ 
Сумма��6%   $ * 64   	 6>   �� *sum+6X   5      �� 5    
   $��1��6   .+�5!      �� -   5        
 ��Name$
 	totaltext��5!   '   
�������$��
Итого��6:   $��16(�6J   6[   5"      �� 5#   
   -   5         ��Name$
 BAck��5#   e   $��
Назад��6   $��1��6!   $��Bottom=�6/   $
��Left=�6J   6�   �� 5$   
   $��1��6   $��1��6"   $��2��62   $��Bottom=�6F   $��Right=�6b    �� Orientation$ 
Horizontal=�6~   .+�5&      �� -   5        $	��Pay��5&   (   $��Оплатить��6   6G   5'      5(      5*      