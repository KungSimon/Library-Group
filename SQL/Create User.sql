CREATE USER 'library_group' IDENTIFIED BY '12345';
GRANT ALL ON library_group_database.* TO 'library_group';
FLUSH PRIVILEGES;
