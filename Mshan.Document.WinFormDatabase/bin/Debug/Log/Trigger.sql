CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_ALERT_LOG" 
 BEFORE
  INSERT
 ON alert_log
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_alert_log.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;
--  Errors handling
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_ALERT_MESSAGE" 
 BEFORE
  INSERT
 ON alert_message
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_alert_message.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;
--  Errors handling
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER trg_atest
 BEFORE
  INSERT
 ON atest
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
    integrity_error   EXCEPTION;
    errno             INTEGER;
    errmsg            CHAR (200);
    curid       NUMBER;
BEGIN
    SELECT seq_atest.NEXTVAL INTO curid FROM DUAL;

    :new.id := curid;
EXCEPTION
    WHEN integrity_error
    THEN
        raise_application_error (errno, errmsg);
END;
/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_ACC_TYPE" 
 BEFORE
  INSERT
 ON base_acc_type
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_acc_type.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;
--  Errors handling
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_APP_PORT" 
 BEFORE
  INSERT
 ON base_app_port
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_app_port.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;
--  ERRORS HANDLING
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_APP_PORT_VER" 
 BEFORE
   INSERT OR UPDATE OF portpty, ipaddr, port, appid
 ON base_app_port
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_app_port_ver.NEXTVAL
     INTO :NEW.ver
     FROM DUAL;
--  ERRORS HANDLING
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_APP_TERM_VER" 
 BEFORE
   INSERT OR UPDATE OF poscode, appid
 ON base_app_term
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_app_term_ver.NEXTVAL
     INTO :NEW.ver
     FROM DUAL;
--  ERRORS HANDLING
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_APP_TERM" 
 BEFORE
  INSERT
 ON base_app_term
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_app_term.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;
--  ERRORS HANDLING
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_BUS_VER" 
 BEFORE
  INSERT OR UPDATE
 ON base_bus
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_bus_ver.NEXTVAL
     INTO :NEW.ver
     FROM DUAL;
--  Errors handling
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_BUS" 
 BEFORE
  INSERT
 ON base_bus
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_bus.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;
--  Errors handling
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_BUS_CHANGELOG" 
 BEFORE
  INSERT
 ON base_bus_changelog
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_bus_changelog.NEXTVAL
     INTO :NEW.id
     FROM DUAL;
--  ERRORS HANDLING
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_BUSINESS_MODEL" 
 BEFORE
  INSERT
 ON base_business_model
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_business_model.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;
--  Errors handling
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_BUSLINE" 
 BEFORE
  INSERT
 ON base_busline
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_busline.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;
--  Errors handling
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_BUSLINE_VER" 
 BEFORE
  INSERT OR UPDATE
 ON base_busline
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_busline_ver.NEXTVAL
     INTO :NEW.ver
     FROM DUAL;
--  Errors handling
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_BUSLINESTOP_VER" 
 BEFORE
  INSERT OR UPDATE
 ON base_buslinestop
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT SEQ_BUSLINESTOP_ver.NEXTVAL
     INTO :NEW.ver
     FROM DUAL;
--  Errors handling
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;




/

CREATE OR REPLACE 
TRIGGER "TRI_BUSLINESTOP" 
  BEFORE INSERT ON BASE_BUSLINESTOP
  FOR EACH ROW

BEGIN
   SELECT SEQ_BUSLINESTOP.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;
END ;
/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_BUSROUTE" 
 BEFORE
  INSERT
 ON base_busroute
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_busroute.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;
--  Errors handling
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_BUSROUTE_VER" 
 BEFORE
  INSERT OR UPDATE
 ON base_busroute
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_busroute_ver.NEXTVAL
     INTO :NEW.ver
     FROM DUAL;
--  Errors handling
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_BUSSTOP" 
 BEFORE
  INSERT
 ON base_busstop
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_busstop.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;
--  Errors handling
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_BUSSTOP_VER" 
 BEFORE
   INSERT OR UPDATE OF longitude, isdelete, latitude
 ON base_busstop
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_busstop_ver.NEXTVAL
     INTO :NEW.ver
     FROM DUAL;
--  Errors handling
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_CARD_REGIST" 
 BEFORE
  INSERT
 ON base_card_regist
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_card_regist.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;
--  Errors handling
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRI_BASE_CARDID" 
 BEFORE
  INSERT
 ON base_cardid
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_cardid.NEXTVAL
     INTO :NEW.cardid
     FROM DUAL;
--  Errors handling
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_CARDTYPE" 
 BEFORE
  INSERT
 ON base_cardtype
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_cardtype.NEXTVAL
     INTO :NEW.TYPEID
     FROM DUAL;
--  Errors handling
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_CHARGAUTH" 
 BEFORE
  INSERT
 ON base_chargeauth
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_chargeauth.NEXTVAL
     INTO :NEW.AUTHCODE
     FROM DUAL;
--  Errors handling
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_CITY_AREA" 
 BEFORE
  INSERT OR UPDATE
 ON base_city_area
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_city_area.NEXTVAL
     INTO :NEW.VER
     FROM DUAL;
--  Errors handling
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_REC_CITY_ERRORCODE" 
 BEFORE
  INSERT OR UPDATE
 ON BASE_CITY_ERRORCODE
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_rec_city_errorcode.NEXTVAL
     INTO :NEW.id
     FROM DUAL;
--  Errors handling
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;




/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TIB_BASE_CITY_ERRORDEALTYPE" 
    BEFORE INSERT
    ON base_city_errordealtype
    REFERENCING NEW AS new OLD AS old
    FOR EACH ROW
DECLARE
    integrity_error   EXCEPTION;
    errno             INTEGER;
    errmsg            CHAR (200);
BEGIN
    SELECT seq_base_city_errordealtype.NEXTVAL INTO :new.cstaccfc FROM DUAL;
EXCEPTION
    WHEN integrity_error
    THEN
        raise_application_error (errno, errmsg);
END;




/

CREATE OR REPLACE 
TRIGGER "CCENSE"."TRG_BASE_CLEARINGRATES" 
 BEFORE
  INSERT
 ON base_clearingrates
REFERENCING NEW AS NEW OLD AS OLD
 FOR EACH ROW
DECLARE
   integrity_error   EXCEPTION;
   errno             INTEGER;
   errmsg            CHAR (200);
BEGIN
   SELECT seq_base_clearingrates.NEXTVAL
     INTO :NEW.ID
     FROM DUAL;
--  Errors handling
EXCEPTION
   WHEN integrity_error
   THEN
      raise_application_error (errno, errmsg);
END;





/

