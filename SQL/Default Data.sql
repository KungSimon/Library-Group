USE library_group_database;

INSERT INTO Category (name) VALUES 
('Fiction'),
('Non-Fiction'),
('Science'),
('History');

INSERT INTO Author (name) VALUES 
('Alice Munro'),
('Malcolm Gladwell'),
('Stephen Hawking'),
('Isaac Asimov'),
('Margaret Atwood');

INSERT INTO Book (title, pages, releasedate, authorid, categoryid) VALUES
('The Story of the Lost Child', 480, 2015, 1, 1),
('Trick Mirror', 320, 2019, 1, 2),
('Talking to Strangers', 400, 2019, 2, 2),
('Outliers', 304, 2008, 2, 2),
('The Tipping Point', 301, 2000, 2, 2),
('A Brief History of Time', 256, 1988, 3, 3),
('The Universe in a Nutshell', 224, 2001, 3, 3),
('The Grand Design', 208, 2010, 3, 3),
('Foundation', 255, 1951, 4, 1),
('I, Robot', 224, 1950, 4, 1),
('Robot Dreams', 352, 1986, 4, 1),
('Prelude to Foundation', 432, 1988, 4, 1),
('The Handmaid\'s Tale', 311, 1985, 5, 1),
('Oryx and Crake', 400, 2003, 5, 1),
('The Year of the Flood', 448, 2009, 5, 1),
('Alias Grace', 460, 1996, 5, 1),
('Cat\'s Eye', 368, 1988, 5, 1),
('Cosmos', 384, 1980, 4, 3),
('Pebble in the Sky', 256, 1950, 4, 3),
('Second Foundation', 210, 1953, 4, 1);