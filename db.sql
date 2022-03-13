use luxWatchDb;
INSERT INTO brands ( name) VALUES
('Rolex'),
('Patek Philippe'),
('Audemars Piguet'),
('Richard Mille'),
('Casio'),
('Hamilton'),
('Omega'),
('Fossil'),
('Bvlgari');

INSERT INTO materials ( type) VALUES
('Stainless Steel'),
('Rose Gold'),
('Yellow Gold'),
('White Gold'),
('Platinium'),
('Saphire'),
('Titanium');

INSERT INTO categories ( sex) VALUES
('Male'),
('Female'),
('Unisex');

INSERT INTO watches ( refnum, brandId, model, size, materialId, categoryId, year, price) VALUES
( '216570', 1, 'Explorer II', 42, 1, 3, 2019, 10650.00),
( '6263', 1, 'Daytona', 37, 3, 1, 1972, 88329.00),
( '116185', 1, 'Datejust', 36, 2, 2, 2010, 16950.00),
( '16610LV', 1, 'Submariner', 40, 1, 1, 2004, 26950.00),
( '5167A', 2, 'Aquanaut', 40.5, 1, 3, 1997, 11750.00),
( '5711/1R', 2, 'Nautilus', 40, 2, 2, 1976, 18350.00),
( '15202OR', 3, 'Royal Oak', 39, 2, 3, 1975, 265240.00),
( '26331ST', 3, 'Royal Oak Chronograph', 41, 1, 1, 1995, 23650.00),
( '116659SABR', 1, 'Submariner Date', 40, 4, 3, 1953, 139450.00),
( 'RM052', 4, 'Tourbillon Skull', 42, 7, 1, 2012, 34950.00);