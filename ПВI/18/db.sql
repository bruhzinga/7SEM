FLUSH PRIVILEGES;

create database wsr;
use wsr;



CREATE TABLE `references`
(
    id      	int(11) NOT NULL AUTO_INCREMENT,
    url         varchar(70) NOT NULL,
    description varchar(70) NOT NULL,
    minus       int(11)     NOT NULL,
    plus        int(11)     NOT NULL,
    PRIMARY KEY (id)
) ENGINE = InnoDB
  DEFAULT CHARSET = latin1;

insert into `references` values (null, 'vk.com', 'vk', 1, 2);
select * from `references`;

CREATE TABLE comment
(
    id      int(11) NOT NULL AUTO_INCREMENT,
    refId     int(11) NOT NULL,
    sessionId varchar(70) DEFAULT NULL,
    stamp     date        DEFAULT NULL,
    comment   varchar(70) DEFAULT NULL,
    PRIMARY KEY (id)
) ENGINE = InnoDB
  AUTO_INCREMENT = 18
  DEFAULT CHARSET = latin1;
  


CREATE PROCEDURE AddReference(
    in url varchar(70),
    in description varchar(70),
    in minus int,
    in plus int)
BEGIN
insert into `references` values (null, url, description, minus, plus);
commit;
END;

CALL AddReference('https://twitter.com', 'twitter', 1, 2);

drop procedure AddComment;

CREATE PROCEDURE AddComment(
    in refId int,
    in sessionId varchar(70),
    in stamp date,
    in comment varchar(70))
BEGIN
insert into comment values (null, refId, sessionId, stamp, comment);
commit;
END;





