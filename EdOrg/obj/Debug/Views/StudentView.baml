   M S B A M L   `   `   `  ����@  <EdOrg, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:EdOrg.ViewsEdOrg.Views  5   	       EdOrg.Views.StudentView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:EdOrg.Views     5   	     � Title$  Student��5   	   $	��450��6   $	��800��6&   .��5	      �� $��Stretch=�6   .+�5
   
   �� -   5         ��Name$ 	btnLogout��5
         	logoutBtn#��[  63     NoMouseOverButtonTemplate#��[ 6V   $
��Left=�6�   .��5      �� $��../Resources/logout.png��6   $��30��66   5      �� 5   
   $��Center=�6   $��Center=�60   $	��350��6M   .+�5   
   �� $��../Resources/sad-pepe.png��6   $	��100��63   $��Center=�6@   �� 5   
   $
��Left=�6   $��10,0,0,0q�6+   .��6=   Дисциплина6I   �� 5   
   -   5         ��Name$ cbxCurrentSubject��5      $��10,0,0,0q�6.   $
��Left=�6h   $��Center=�6�   $	��100��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgMarks��5   d   $��Bottom=�6      
IsReadOnly .    CanUserAddRows .  $��10q�6X      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Дата��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 64   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6>   �� *	CreatedAt+  5      $ Дисциплина��6%   $	 * 6:   
 6D   �� *Subjects.Name+  5      $ Оценка��6%   $	 * 65   
 6?   �� *Value+5      5      5      5      