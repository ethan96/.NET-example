   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.Window1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  Window1��5   	   $	��300��6   $	��600��6&    � 	Resources 5	         storeViewSource��%   &	        �� 5
   
   6   5      .��5      �  � DataContext# [  6   $��
0,0,-248,0q�6:   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ storeDataGrid��5         AutoGenerateColumns .     EnableRowVirtualization . $��10,59,308,10q�6}      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�   ��6e   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        
cityColumn��,  &System.Windows.Controls.DataGridColumn   Header$
 city��5   R   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 SizeToHeader 6`   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 69   �� *city+6`     5      -   5        stateColumn��$ state��5   T   $	 SizeToHeader 6c   
 6:   �� *state+6c     5      -   5        stor_addressColumn��$ stor address��5   b   $	 SizeToHeader 6x   
 6A   �� *stor_address+6x     5      -   5        stor_idColumn��$ stor id��5   X   $	 SizeToHeader 6i   
 6<   �� *	stor_id+6i     5      -   5        stor_nameColumn��$ 	stor name��5   \   $	 SizeToHeader 6o   
 6>   �� *	stor_name+6o     5      -   5        	zipColumn��$	 zip��5   P   $	 SizeToHeader 6]   
 68   �� *zip+6]   5      5      5      