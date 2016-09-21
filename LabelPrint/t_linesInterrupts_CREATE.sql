-- Table: "t_linesInterrupts"

-- DROP TABLE "t_linesInterrupts";

CREATE TABLE "t_linesInterrupts"
(
  "interruptNo" serial NOT NULL, -- Номер
  "accidentDate" date, -- Дата
  gang character varying, -- Смена
  "lineID" character varying, -- Идентификатор линии, с1  в других таблицах
  "equipmentName" character varying, -- Название оборудования
  "interruptTimestamp" time without time zone, -- Время остановки оборудования
  "beginRepairTimestamp" time without time zone, -- Время начала ремонта
  "endOfInterruptTimestamp" time without time zone, -- Время запуска оборудования
  "interruptCode" character varying, -- Код простоя
  "causeOfInterrupt" character varying, -- Причина отказа (описание неисправности)
  "carriedOutActions" character varying, -- Проведенные действия
  "whoIsLast" character varying, -- Подпись ответственного лица
  CONSTRAINT "t_linesInterrupts_pkey" PRIMARY KEY ("interruptNo")
)
WITH (
  OIDS=FALSE
);
ALTER TABLE "t_linesInterrupts"
  OWNER TO postgres;
COMMENT ON COLUMN "t_linesInterrupts"."interruptNo" IS 'Номер';
COMMENT ON COLUMN "t_linesInterrupts"."accidentDate" IS 'Дата';
COMMENT ON COLUMN "t_linesInterrupts".gang IS 'Смена';
COMMENT ON COLUMN "t_linesInterrupts"."lineID" IS 'Идентификатор линии, с1  в других таблицах';
COMMENT ON COLUMN "t_linesInterrupts"."equipmentName" IS 'Название оборудования';
COMMENT ON COLUMN "t_linesInterrupts"."interruptTimestamp" IS 'Время остановки оборудования';
COMMENT ON COLUMN "t_linesInterrupts"."beginRepairTimestamp" IS 'Время начала ремонта';
COMMENT ON COLUMN "t_linesInterrupts"."endOfInterruptTimestamp" IS 'Время запуска оборудования';
COMMENT ON COLUMN "t_linesInterrupts"."interruptCode" IS 'Код простоя';
COMMENT ON COLUMN "t_linesInterrupts"."causeOfInterrupt" IS 'Причина отказа (описание неисправности)';
COMMENT ON COLUMN "t_linesInterrupts"."carriedOutActions" IS 'Проведенные действия';
COMMENT ON COLUMN "t_linesInterrupts"."whoIsLast" IS 'Подпись ответственного лица';

