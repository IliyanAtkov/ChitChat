/** Users table */
CREATE TABLE users (
	id int(11) NOT_NULL AUTO_INCREMENT,
	username varchar(30) NOT_NULL,
	password char(30) NOT_NULL,
	email varchar(90),
	joinDate DATE NOT NULL,
	ip varchar(15) NOT NULL,
	info tinytext DEFAULT NULL,
	city varchar(20) DEFAULT NULL,
	nation varchar(20) DEFAULT NULL,
	phone int(16) DEFAUL NULL,
	sex ENUM('Male','Female', 'Unknown') DEFAULT 'Unknown',
	name varchar(100) DEFAULT NULL,
	isDonator tinyint(1) NOT NULL,
	onlineStance ENUM('Online', 'Busy', 'AFK', 'Ghost', 'Offline'),
	PRIMARY KEY(id)
);