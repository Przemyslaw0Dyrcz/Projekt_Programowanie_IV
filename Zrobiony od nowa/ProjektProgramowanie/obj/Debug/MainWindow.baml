   M S B A M L   `   `   `  ����  ProjektProgramowanie%    ProjektProgramowanie.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Wypożyczalnia Filmów��5   	   $	��500��6&   $	��790��63   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5	      $
��Auto �6   �� 5
      $��50 �6   .+�5   
   �� -   5         ��Name$ CustomerListBox��5      $��0��6   $��
10,10,0,10q�68   ��5      �� 5      .R�5      �� .+�5      �� $
��Bold"�6:   ��6$   �� *Imie+6:   �� 5      ��6$   �� *
Nazwisko+�� 5      ��6$   �� *	IDklienta+ �� StringFormat$ ID: {0}��5      5      5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   .+�5      �� -   5         ��Name$ SearchTextBox��5      $	��200��6-   $��0,0,10,0q�69   $��Wyszukaj po IDklienta��6K   �� 5      -   5        $��Szukaj��5      6&   5      �� 5   
   -   5        $��2��5      $��Dodaj nowego klienta��6   $��10q�6=   6I   �� 5    
   -   5         ��Name$ MainContent��5       $��0,0,0,10q�6.   $��3��6@   5"      5#      5$      