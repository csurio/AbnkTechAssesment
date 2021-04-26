CREATE USER 'usrabnk'@'%' IDENTIFIED BY 'Admin1234';

GRANT ALL PRIVILEGES ON abnk_inventory . * TO 'usrabnk'@'%';

FLUSH PRIVILEGES;