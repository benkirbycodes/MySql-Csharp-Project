USE burgershack123;

DROP TABLE IF EXISTS burgers;
CREATE TABLE burgers (
    id int NOT NULL AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    `price` DECIMAL DEFAULT 0,
    description VARCHAR(255) NOT NULL,
    PRIMARY KEY (id)
);

-- -- NOTE putting backticks on price solved "unknown column" error
-- DELETE FROM burgers

