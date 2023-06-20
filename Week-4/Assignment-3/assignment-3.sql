SELECT Article.*, [user].email AS author_email
FROM Article
JOIN [user] ON Article.author_id = [user].id;


SELECT *
FROM Article 
ORDER BY id
OFFSET 6 ROWS
FETCH NEXT 6 ROWS ONLY;

