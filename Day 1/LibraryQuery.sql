--Step 1: Create the Members Table
CREATE TABLE members (
 member_id SERIAL PRIMARY KEY,
 first_name VARCHAR(100) NOT NULL,
 last_name VARCHAR(100) NOT NULL,
 email VARCHAR(255) UNIQUE NOT NULL,
 created_date TIMESTAMPTZ NOT NULL DEFAULT NOW(),
 updated_date TIMESTAMPTZ,
 active BOOLEAN
);

--Step 2: Select All Members
SELECT * FROM members;

--Step 3: Drop Members Table If Exists
DROP TABLE IF EXISTS members;

--Step 4: Add a New Column to Members
ALTER TABLE members ADD COLUMN phone VARCHAR(15);

--Step 5: Drop the Newly Added Column
ALTER TABLE members DROP COLUMN phone;

--Step 6: Rename Columns
ALTER TABLE members RENAME COLUMN email TO email_address;
ALTER TABLE members RENAME COLUMN email_address TO email;

--Step 7: Rename Table
ALTER TABLE members RENAME TO library_members;
ALTER TABLE library_members RENAME TO members;

--Step 8: Create Books Table
CREATE TABLE books (
 book_id SERIAL PRIMARY KEY,
 member_id INTEGER REFERENCES members(member_id),
 borrow_date TIMESTAMPTZ NOT NULL DEFAULT NOW(),
 return_date TIMESTAMPTZ,
 title VARCHAR(200) NOT NULL,
 price DECIMAL(10, 2) NOT NULL
);

--Step 9: Insert a Single Member
INSERT INTO members(first_name, last_name, email, created_date, updated_date, active)
VALUES ('Aarti', 'Desai', 'aarti.desai@example.com', NOW(), NULL, true);

--Step 10: Insert Multiple Members
INSERT INTO members(first_name, last_name, email, created_date, updated_date, active)
VALUES
 ('Ravi', 'Patel', 'ravi.patel@example.com', NOW(), NULL, true),
 ('Neha', 'Sharma', 'neha.sharma@example.com', NOW(), NULL, true),
 ('Amit', 'Mehta', 'amit.mehta@example.com', NOW(), NULL, false),
 ('Priya', 'Rao', 'priya.rao@example.com', NOW(), NULL, true),
 ('Karan', 'Singh', 'karan.singh@example.com', NOW(), NULL, false),
 ('Divya', 'Kapoor', 'divya.kapoor@example.com', NOW(), NULL, true),
 ('Ankit', 'Yadav', 'ankit.yadav@example.com', NOW(), NULL, true),
 ('Sneha', 'Verma', 'sneha.verma@example.com', NOW(), NULL, false),
 ('Rahul', 'Joshi', 'rahul.joshi@example.com', NOW(), NULL, true),
 ('Jaya', 'Nair', 'jaya.nair@example.com', NOW(), NULL, false);

 --Step 11: Insert Book Records
 INSERT INTO books (member_id, borrow_date, return_date, title, price) VALUES
 (1, '2024-01-01', '2024-01-15', 'The Alchemist', 350.00),
 (2, '2024-01-03', NULL, 'To Kill a Mockingbird', 280.50),
 (3, '2024-01-05', '2024-01-20', '1984', 400.75),
 (4, '2024-01-07', NULL, 'The Great Gatsby', 250.00),
 (5, '2024-01-10', NULL, 'Atomic Habits', 500.00),
 (1, '2024-01-12', NULL, 'Rich Dad Poor Dad', 300.00),
 (2, '2024-01-13', NULL, 'The Power of Now', 450.00),
 (1, '2024-01-15', NULL, 'Sapiens', 600.00);

--Step 12: Basic Select Queries
SELECT first_name FROM members;
SELECT first_name, last_name, email FROM members;
SELECT * FROM members;

--Step 13: ORDER BY Queries
SELECT first_name, last_name FROM members ORDER BY first_name ASC;
SELECT first_name, last_name FROM members ORDER BY last_name DESC;
SELECT member_id, first_name, last_name FROM members ORDER BY first_name ASC, last_name
DESC;

--Step 14: WHERE Clause Examples
SELECT * FROM members WHERE first_name = 'Aarti';
SELECT member_id FROM members WHERE first_name = 'Aarti' AND last_name = 'Desai';
SELECT * FROM members WHERE first_name IN ('Ravi', 'Amit', 'Sneha');
SELECT * FROM members WHERE first_name LIKE '%ya%';
SELECT * FROM members WHERE first_name ILIKE '%YA%';

--Step 15: JOIN Examples
SELECT * FROM books AS b INNER JOIN members AS m ON b.member_id = m.member_id;
SELECT * FROM members AS m LEFT JOIN books AS b ON m.member_id = b.member_id;

--Step 16: Aggregation with GROUP BY
SELECT m.member_id, m.first_name, m.last_name, COUNT(b.book_id) AS books_borrowed,
 SUM(b.price) AS total_price
FROM members AS m
INNER JOIN books AS b ON m.member_id = b.member_id
GROUP BY m.member_id;

--Step 17: GROUP BY with HAVING
SELECT m.member_id, m.first_name, m.last_name, COUNT(b.book_id) AS books_borrowed,
 SUM(b.price) AS total_price
FROM members AS m
INNER JOIN books AS b ON m.member_id = b.member_id
GROUP BY m.member_id
HAVING COUNT(b.book_id) > 1;

--Step 18: Subqueries
SELECT * FROM books WHERE member_id IN (
 SELECT member_id FROM members WHERE active = true
);
SELECT member_id, first_name, last_name, email FROM members WHERE EXISTS (
 SELECT 1 FROM books WHERE books.member_id = members.member_id
);

--Step 19: UPDATE Statement
UPDATE members
SET first_name = 'Aarti', last_name = 'Desai', email = 'aarti.desai@newmail.com'
WHERE member_id = 1;

--Step 20: DELETE Statement
DELETE FROM members WHERE member_id = 10;
