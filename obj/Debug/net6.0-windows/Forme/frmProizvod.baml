   M S B A M L   `   `   `  ����B  >Apoteka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Apoteka.FormeApoteka.Forme  5   	       Apoteka.Forme.frmProizvod   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Apoteka.Forme     5   	     � Title$  Dodaj/Izmeni proizvod��5   	   $	��350��6'   $	��350��64   .��5	      � ���#d0dfe7.+�5
   
   �� $��Naziv proizvoda��6   $
��Left=�6*   $��	30,20,0,0q�6E   $	��Top=�6X   �� 5   
   $��Proizvođač��6   $
��Left=�6%   $��	30,50,0,0q�6@   $	��Top=�6S   �� 5   
   $
��Cena��6   $
��Left=�6   $��	30,80,0,0q�6:   $	��Top=�6M   �� 5   
   $��Rok trajanja��6   $
��Left=�6'   $��
30,110,0,0q�6B   $	��Top=�6V   �� 5   
   $��Tip proizvoda��6   $
��Left=�6(   $��
30,140,0,0q�6C   $	��Top=�6W   �� 5   
   $��Recept��6   $
��Left=�6!   $��
30,170,0,0q�6<   $	��Top=�6P   �� 5   
   $��Količina na stanju��6   $
��Left=�6-   $��
30,200,0,0q�6H   $	��Top=�6\   �� 5   
   $��
Dobavljač��6   $
��Left=�6$   $��
30,230,0,0q�6?   $	��Top=�6S   �� 5   
   -   5         ��Name$ txtNazivProizvoda��5      $
��Left=�6-   $��
150,20,0,0q�6H   $��23��6\    �� TextWrapping$
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ txtProizvodjacProizvoda��5      $
��Left=�63   $��
150,50,0,0q�6N   $��23��6b   $
 Wrap=�6n   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ txtCenaProizvoda��5      $
��Left=�6,   $��
150,80,0,0q�6G   $��23��6[   $
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��120��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpRokTrajanja��5      $
��Left=�6,   $��150,110,0,0q�6G   $	��Top=�6\   $	��120��6t   �� 5   
   -   5        $ txtTipProizvoda��5      $
��Left=�6+   $��150,140,0,0q�6F   $��23��6[   $
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ 	cbxRecept��5      $�� ��6&   $
��Left=�61   $��160,175,0,0q�6L   $	��Top=�6a   �� 5   
   -   5        $ txtKolicinaNaStanju��5      $
��Left=�6/   $��150,200,0,0q�6J   $��23��6_   $
 Wrap=�6k   $�� ��6   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ cbDobavljac��5      $
��Left=�6(   $��150,230,0,0q�6C   $	��Top=�6X   $	��120��6p    �� DisplayMemberPath$ NazivDobavljaca��6|    �� SelectedValuePath$ DobavljacID��6�   �� 5   
   -	   5         ��Name$ btnDodajDobavljaca��5      $	��Add��6-   $
��Left=�6;   $��280,230,0,0q�6V   $��40��6k   $	��Top=�6v   ���#234e98
����������#234e98$��1q�5   q   6�   �� 5    
   -
   5        $ 
btnSacuvaj��5       $��Sačuvaj��6%   $
��Left=�67   $��100,275,0,0q�6R   $��75��6g   $	��Top=�6r   ���#234e98
����������#234e98$��1q�5!   i   	 �� 	IsDefault$
	 True��6�   �� 5"   
   -   5        $ 	btnOtkazi��5"      $��Otkaži��6$   $
��Left=�65   $��200,275,0,0q�6P   $��75��6e   $	��Top=�6p   ���#234e98
����������#234e98$��1q�5#   h   6|   5$      5%      