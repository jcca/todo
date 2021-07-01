CREATE SCHEMA demo;
CREATE TABLE demo."todos"
(
    id bigserial NOT NULL,
    nombre text NOT NULL,
    descripcion text,
    PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
);
ALTER TABLE demo."todos"
    OWNER to postgres;