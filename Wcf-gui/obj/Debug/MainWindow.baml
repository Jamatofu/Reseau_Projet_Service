   M S B A M L   `   `   `  ����B  >Wcf-gui, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Wcf_guiWcf_gui  5   	       Wcf_gui.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Wcf_gui     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      � .+�5
   
   �� $��Vélo france��6   $��Center=�6'   $��28��6D   $��153,10,140.4,0q�6P   $	��Top=�6h   $	��225��6�   �� 5   
   -   5        $��station��5      $
��Left=�6:   $��26��6U   $��	91,69,0,0q�6a    �� TextWrapping$
 Wrap=�6t   $	��Top=�6�   $	��200��6�   ��6!   �� *	Station+6�   �� 5   
   -   5        $��ville��5      $
��Left=�66   $��41��6Q   $��
91,115,0,0q�6]   $
 Wrap=�6q   $	��Top=�6�   $	��200��6�   ��6   �� *Ville+6�   �� 5   
   -   5        $ ��Nombre de vélo disponible��5      $
��Left=�65   $��26��6P   $��
314,69,0,0q�6\   $	��Top=�6p   $	��194��6�   6�   �� 5   
   -   5        $��Station disponible��5      $
��Left=�6.   $��41��6I   $��314,115,0,0q�6U   $	��Top=�6j   $	��194��6�   6�   �� 5   
   $��Station��6   $
��Left=�6"   $	��Top=�6=   $��	10,69,0,0q�6U   $��76��6h   �� 5   
   $��Ville��6   $
��Left=�6    $	��Top=�6;   $��
10,122,0,0q�6S   $��76��6g   �� 5   
   -   5        $��listView��5      $
��Left=�6#   $	��153��6>   $��0,168,0,-0.2q�6K   $	��Top=�6a   $	��518��6y    �� View 5      �� 5      .P�5      �� $��Station��5       �� Width$	 150��6N    �� DisplayMemberBinding 6(   �� *name+6N   �� 5      $��Vélo(s)��5      $	 150��6Y    6(   �� *available_bikes+6Y   �� 5      $��Adresse��5      $	 150��6Q    6(   �� *	address+6Q   5      5      5       5!      