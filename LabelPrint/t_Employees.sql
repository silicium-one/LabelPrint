-- Table: "t_Employees"

-- DROP TABLE "t_Employees";

CREATE TABLE "t_Employees"
(
  "ID" serial NOT NULL,
  "Name" text NOT NULL,
  "BC" text NOT NULL,
  CONSTRAINT "t_Employees_pkey" PRIMARY KEY ("ID"),
  CONSTRAINT "t_Employees_BC_key" UNIQUE ("BC")
)
WITH (
  OIDS=FALSE
);
ALTER TABLE "t_Employees" OWNER TO postgres;
COMMENT ON TABLE "t_Employees" IS 'Таблица сотрудников. В настоящее время используется как таблица тех, кто может начать ремонт оборудования при простое';
