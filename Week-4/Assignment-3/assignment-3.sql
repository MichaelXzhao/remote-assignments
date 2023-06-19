SELECT Article.*, [user].email AS author_email
FROM Article
JOIN [user] ON Article.author_id = [user].id;


SELECT *
FROM Article
WHERE id BETWEEN 7 AND 12;
