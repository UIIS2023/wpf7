   M S B A M L   `   `   `  ����B  >Apoteka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Apoteka.FormeApoteka.Forme  5   	       Apoteka.Forme.frmKorisnik   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Apoteka.Forme     5   	     � Title$  Dodaj/Izmeni korisnika��5   	   $	��330��6(   $	��318��65   .��5	      � ���#d0dfe7.+�5
   
   �� $	��Ime��6   $
��Left=�6   $��	30,20,0,0q�69   $	��Top=�6L   �� 5   
   $��Prezime��6   $
��Left=�6"   $��	30,50,0,0q�6=   $	��Top=�6P   �� 5   
   $
��JMBG��6   $
��Left=�6   $��	30,80,0,0q�6:   $	��Top=�6M   �� 5   
   $
��Grad��6   $
��Left=�6   $��
30,110,0,0q�6:   $	��Top=�6N   �� 5   
   $��Adresa��6   $
��Left=�6!   $��
30,140,0,0q�6<   $	��Top=�6P   �� 5   
   $��Kontakt��6   $
��Left=�6"   $��
30,170,0,0q�6=   $	��Top=�6Q   �� 5   
   $��Pozicija��6   $
��Left=�6#   $��
30,200,0,0q�6>   $	��Top=�6R   �� 5   
   -   5         ��Name$ txtIme��5      $
��Left=�6"   $��
130,20,0,0q�6=   $��23��6Q    �� TextWrapping$
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��120��6�   �� 5   
   -   5        $ 
txtPrezime��5      $
��Left=�6&   $��
130,50,0,0q�6A   $��23��6U   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   �� 5   
   -   5        $ txtJMBG��5      $
��Left=�6#   $��
130,80,0,0q�6>   $��23��6R   $
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   �� 5   
   -   5        $ txtGrad��5      $
��Left=�6#   $��130,110,0,0q�6>   $��23��6S   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��120��6�   �� 5   
   -   5        $ 	txtAdresa��5      $
��Left=�6%   $��130,140,0,0q�6@   $��23��6U   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   �� 5   
   -   5        $ 
txtKontakt��5      $
��Left=�6&   $��130,170,0,0q�6A   $��23��6V   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��120��6�   �� 5   
   -   5         ��Name$ 
cbPozicija��5      $
��Left=�6'   $��130,200,0,0q�6B   $	��Top=�6W   $	��120��6o    �� DisplayMemberPath$ NazivPozicije��6{    �� SelectedValuePath$ 
PozicijaID��6�   �� 5   
   -   5         ��Name$ btnDodajPoziciju��5      $	��Add��6+   $
��Left=�69   $��255,202,0,0q�6T   $��40��6i   $	��Top=�6t   ���#234e98
����������#234e98$��1q�5   o   6�   �� 5   
   -	   5        $ 
btnSacuvaj��5      $��Sačuvaj��6%   $
��Left=�67   $��
84,255,0,0q�6R   $��75��6f   $	��Top=�6q   ���#234e98
����������#234e98$��1q�5   i    �� 	IsDefault$
 True��6�   �� 5   
   -
   5        $ 	btnOtkazi��5      $��Otkaži��6$   $
��Left=�65   $��200,255,0,0q�6P   $��75��6e   $	��Top=�6p   ���#234e98
����������#234e98$��1q�5    h   6|   5"      5#      