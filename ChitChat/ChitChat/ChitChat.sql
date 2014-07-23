/** Users table */
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(30) COLLATE utf8_bin NOT NULL,
  `password` char(30) COLLATE utf8_bin NOT NULL,
  `email` varchar(90) COLLATE utf8_bin DEFAULT NULL,
  `joinDate` date NOT NULL,
  `ip` varchar(15) COLLATE utf8_bin NOT NULL,
  `info` tinytext COLLATE utf8_bin,
  `city` varchar(20) COLLATE utf8_bin DEFAULT NULL,
  `nation` varchar(20) COLLATE utf8_bin DEFAULT NULL,
  `phone` int(16) DEFAULT NULL,
  `sex` enum('Male','Female','Unknown') COLLATE utf8_bin DEFAULT 'Unknown',
  `name` varchar(100) COLLATE utf8_bin DEFAULT NULL,
  `isDonator` tinyint(1) NOT NULL,
  `onlineStance` enum('Online','Busy','AFK','Ghost','Offline') COLLATE utf8_bin NOT NULL DEFAULT 'Offline',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=3 ;