   M S B A M L   `   `   `  ����B  >Apoteka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Apoteka.FormeApoteka.Forme  5   	       Apoteka.Forme.frmRecept   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Apoteka.Forme     5   	     � Title$  Dodaj/Izmeni recept��5   	   $	��175��6%   $	��300��62   .��5	      � ���#d0dfe7.+�5
   
   �� $��Kupac��6   $
��Left=�6    $��	30,20,0,0q�6;   $	��Top=�6N   �� 5   
   $��Proizvod��6   $
��Left=�6#   $��	30,50,0,0q�6>   $	��Top=�6Q   �� 5   
   -   5         ��Name$ cbKupac��5      $
��Left=�6$   $��
100,20,0,0q�6?   $	��Top=�6S   $	��120��6k    �� DisplayMemberPath$ kupac��6w    �� SelectedValuePath$ KupacID��6�   �� 5   
   -   5         ��Name$ btnDodajKupca��5      $	��Add��6(   $
��Left=�66   $��
230,20,0,0q�6Q   $��40��6e   $	��Top=�6p   ���#234e98
����������#234e98$��1q�5   l   6�   �� 5   
   -   5        $ 
cbProizvod��5      $
��Left=�6'   $��
100,50,0,0q�6B   $	��Top=�6V   $	��120��6n   $ NazivProizvoda��6z   $ 
ProizvodID��5   '   �� 5   
   -   5        $ btnDodajProizvod��5      $	��Add��6+   $
��Left=�69   $��
230,50,0,0q�6T   $��40��6h   $	��Top=�6s   ���#234e98
����������#234e98$��1q�5   o   6�   �� 5   
   -   5        $ 
btnSacuvaj��5      $��Sačuvaj��6%   $
��Left=�67   $��
45,105,0,0q�6R   $��75��6f   $	��Top=�6q   ���#234e98
����������#234e98$��1q�5   i    �� 	IsDefault$
 True��6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkaži��6$   $
��Left=�65   $��160,105,0,0q�6P   $��75��6e   $	��Top=�6p   ���#234e98
����������#234e98$��1q�5   h   6|   5      5      