-- Table: "t_linesBreaks"

-- DROP TABLE "t_linesBreaks";

CREATE TABLE "t_linesBreaks"
(
  "ID" integer NOT NULL, -- Первичный ключ
  "lineID" character varying, -- Идентификатор линии,...
  "beginBreakTime" time without time zone, -- начало перерыва
  "endBreakTime" time without time zone, -- конец перерыва
  comment text, -- характер перерыва
  CONSTRAINT "t_linesBreaks_pkey" PRIMARY KEY ("ID")
)
WITH (
  OIDS=FALSE
);
ALTER TABLE "t_linesBreaks"
  OWNER TO postgres;
COMMENT ON TABLE "t_linesBreaks"
  IS 'Таблица запланированных перерывов в работе линии';
COMMENT ON COLUMN "t_linesBreaks"."ID" IS 'Первичный ключ';
COMMENT ON COLUMN "t_linesBreaks"."lineID" IS 'Идентификатор линии,
с1  в других таблицах';
COMMENT ON COLUMN "t_linesBreaks"."beginBreakTime" IS 'начало перерыва';
COMMENT ON COLUMN "t_linesBreaks"."endBreakTime" IS 'конец перерыва';
COMMENT ON COLUMN "t_linesBreaks".comment IS 'характер перерыва';

