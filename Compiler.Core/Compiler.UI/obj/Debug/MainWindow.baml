   M S B A M L   `   `   `  ����F  BCompiler.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Compiler.UI.ExtentionCompiler.UI.Extention  5   	       Compiler.UI.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   T PMahApps.Metro, Version=1.3.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   ] YICSharpCode.AvalonEdit, Version=5.0.3.0, Culture=neutral, PublicKeyToken=9cc39be672370310?
avalonEdit.http://icsharpcode.net/sharpdevelop/avalonedit  5   	   3	extention#clr-namespace:Compiler.UI.Extention  5   	     � Title$  PARSER��5   	   $	��650��6   $
��1120��6%   .��5      � .+�5	   
   ]� ���#d6dbe9��. .+�5
      �� ���#3a5068$
��Menu��6,   $	��Top=�6:   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5        $��Compile��5      6L   5      5      �� 5      ���#3a5068$
��Left=�6,   $��10q�6B   $��Source��6N   .��5      '  !ICSharpCode.AvalonEdit.TextEditor  -   5        $��Source��5   (   $��Consolas)�5   (   $
��10pt(�5   (      SyntaxHighlightingM  GICSharpCode.AvalonEdit.Highlighting.HighlightingDefinitionTypeConverter$ VBNET 5   (   $��Center=�5   (   $   HorizontalScrollBarVisibility$ Visible=�5   (   "   VerticalScrollBarVisibility$ Visible=�5   (      
IsReadOnly .     Text$  ��5   ;   $	��300��6C   . 6O   5      5      �� 5      ���#fff19c$��OUTPUT��6,   $��Bottom=�6<   .��5      �� $	��100��6   ��6'   �� *Output+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ OneWay=�6z   5      �� 5      ���#3a5068$��10q�6,   $��Results��68   .��5      �� ���#eaeaec$ 
Horizontal=�62   .+�5      � 	 � RowDefinitions	 5       �� 5!      $
��147* �6,   �� 5"      $
��190* �6,   
 � ColumnDefinitions
 5$      �� 5%      $
��250* �6/   �� 5&      $
��200* �6/   �� 5'      $
��300* �6/   .+�5)      �� $��10q�6'   $��0��63   $
��Auto=�6C   $��2��6f   .��5*      �� ��6'   �� *KeywordItems+ �� View 5,   "   �� 5-   &    �� AllowsColumnReorder . .P�5.   *   �� $��Index J��6k    �� Width$ 60��6|    �� DisplayMemberBinding 69   ��  �� Path$ LookupIndex�6|   �� 5/   *   $��Keyword��6e   $	 200��6v    69   �� $ Value�6v   50   '   52      53      �� 55      $��10q�6(   $��0��64   $��1��6A   $
��Auto=�6Q   .��56      �� ��6'   �� *IdentificatorsItems+ 57   "   �� 58   &    . .P�59   *   �� $��Index��6k   $ 60��6z    69   �� $ LookupIndex�6z   �� 5:   *   $��Identificator��6e   $	 200��6|    69   �� $ Value�6|   5;   '   5=      5>      �� 5@      $��1��6'   $��10q�64   $��1��6@   $
��Auto=�6P   .��5A      �� ��6'   �� *ConstantItems+ 5B   "   �� 5C   &    . .P�5D   *   �� $��Index��6k   $ 60��6z    69   �� $ LookupIndex�6z   �� 5E   *   $��literal��6e   $	 200��6v    69   �� $ Value�6v   5F   '   5H      5I      �� 5K      $��0��6'   $��2��64   $��10q�6E   $��2��6Q   $
��Auto=�6a   .��5L      �� ��6'   �� *StandartItems+ 5M   "   �� 5N   &    . .P�5O   *   �� $
��Type��6i   $ 90��6w    69   �� $ 	LexemType�6w   �� 5P   *   $��Index��6k   $ 60��6z    69   �� $ LookupIndex�6z   �� 5Q   *   $��Lexem��6e   $	 100��6t    69   �� $ Value�6t   5R   '   5T      5U      5V      5X      5Y      5Z      5\      5^      