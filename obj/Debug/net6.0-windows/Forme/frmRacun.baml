   M S B A M L   `   `   `  ����B  >Apoteka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Apoteka.FormeApoteka.Forme  5   	       Apoteka.Forme.frmRacun   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Apoteka.Forme     5   	     � Title$  Dodaj/Izmeni račun��5   	   $	��275��6$   $	��325��61   .��5	      � ���#d0dfe7.+�5
   
   �� $��Datum izdavanja��6   $
��Left=�6*   $��	20,20,0,0q�6E   $	��Top=�6X   �� 5   
   $��Ukupna cena��6   $
��Left=�6&   $��	20,50,0,0q�6A   $	��Top=�6T   �� 5   
   $��Broj računa��6   $
��Left=�6&   $��	20,80,0,0q�6A   $	��Top=�6T   �� 5   
   $��Kupac��6   $
��Left=�6    $��
20,110,0,0q�6;   $	��Top=�6O   �� 5   
   $��Korisnik��6   $
��Left=�6#   $��
20,140,0,0q�6>   $	��Top=�6R   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpDatumIzdavanja��5      $
��Left=�6/   $��
130,20,0,0q�6J   $	��Top=�6^   $	��120��6v   �� 5   
   -   5         ��Name$ txtUkupnaCena��5      $
��Left=�6)   $��
130,50,0,0q�6D   $��23��6X    �� TextWrapping$
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ txtBrojRacuna��5      $
��Left=�6)   $��
130,80,0,0q�6D   $��23��6X   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ cbKupac��5      $
��Left=�6$   $��130,110,0,0q�6?   $	��Top=�6T   $	��120��6l    �� DisplayMemberPath$ kupac��6x    �� SelectedValuePath$ KupacID��6�   �� 5   
   -   5         ��Name$ btnDodajKupca��5      $	��Add��6(   $
��Left=�66   $��260,110,0,0q�6Q   $��40��6f   $	��Top=�6q   ���#234e98
����������#234e98$��1q�5   l   6�   �� 5   
   -   5        $ 
cbKorisnik��5      $
��Left=�6'   $��130,140,0,0q�6B   $	��Top=�6W   $	��120��6o   $ korisnik��6{   $ 
KorisnikID��6�   �� 5   
   -   5        $ btnDodajKorisnika��5      $	��Add��6,   $
��Left=�6:   $��260,142,0,0q�6U   $��40��6j   $	��Top=�6u   ���#234e98
����������#234e98$��1q�5   p   6�   �� 5   
   -   5        $ 
btnSacuvaj��5      $��Sačuvaj��6%   $
��Left=�67   $��
55,200,0,0q�6R   $��75��6f   $	��Top=�6q   ���#234e98
����������#234e98$��1q�5   i    �� 	IsDefault$
 True��6�   �� 5   
   -	   5        $ 	btnOtkazi��5      $��Otkaži��6$   $
��Left=�65   $��175,200,0,0q�6P   $��75��6e   $	��Top=�6p   ���#234e98
����������#234e98$��1q�5   h   6|   5!      5"      