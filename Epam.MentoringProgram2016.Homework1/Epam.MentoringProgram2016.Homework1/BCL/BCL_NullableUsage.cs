﻿//Пример использования Nullable типа вне базы данных и ORM:

//    Предположим, мы пишем игру, в которой происходит развитие главного персонажа на протяжении многих
//    уровней.
//    На каждом этапе развития персонажа игроку открывается определённый набор заклинаний.
//    В начале игры у персонажа отсутствуют или ограничено количество заклинаний, а значит,
//    в классе, который представляет активного персонажа, хранится полный набор Nullable полей, которые
//    идут в соответствии всеми возможными заклинаниями данного персонажа.
//    Эти nullable поля изначально выставлены в null, а базе данных совершенно необязательно знать о
//    временном внутреннем состоянии класса персонажа.
    
//        А значит по мере его развития nullable поля, проставленные в null, будут инициализироваться
//        определёнными значениями, соответствующими приобретённым заклинаниям.