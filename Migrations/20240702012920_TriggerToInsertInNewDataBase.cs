using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AQRSimportandexportarchives.Migrations
{
    /// <inheritdoc />
    public partial class TriggerToInsertInNewDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createTrigger = @"
                    CREATE TRIGGER arqs_alan.tgr_send_data_to_new_database AFTER INSERT ON arqs_alan.t_media
					FOR EACH ROW
					BEGIN
						IF (SELECT COUNT(*) FROM arqs_alan_new.t_genre WHERE name = NEW.genre) = 0 THEN
							INSERT INTO arqs_alan_new.t_genre (id, name, created_date) VALUES (UUID(), NEW.genre, NOW());
						END IF;
	
						IF (SELECT COUNT(1) FROM arqs_alan_new.t_category WHERE name = NEW.category) = 0 THEN
							INSERT INTO arqs_alan_new.t_category (id, name, created_date) VALUES (UUID(), NEW.category, NOW());
						END IF;
	
						IF (SELECT COUNT(1) FROM arqs_alan_new.t_media WHERE name = NEW.media_name) = 0 THEN
							INSERT INTO arqs_alan_new.t_media (id, name, created_date) VALUES (UUID(), NEW.media_name, NOW());
						END IF;
	
						IF (SELECT COUNT(1) FROM arqs_alan_new.t_media_type WHERE name = NEW.media_type) = 0 THEN
							INSERT INTO arqs_alan_new.t_media_type (id, name, created_date) VALUES (UUID(), NEW.media_type, NOW());
						END IF;
	
						IF (SELECT COUNT(1) FROM arqs_alan_new.t_rating WHERE name = NEW.rating) = 0 THEN
							INSERT INTO arqs_alan_new.t_rating (id, name, created_date) VALUES (UUID(), NEW.rating, NOW());
						END IF;
	
						IF (SELECT COUNT(1) FROM arqs_alan_new.t_participant WHERE name = NEW.participant) = 0 THEN
							INSERT INTO arqs_alan_new.t_participant (id, name, created_date) VALUES (UUID(), NEW.participant, NOW());
						END IF;
					END
                ";

            migrationBuilder.Sql(createTrigger);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropTrigger = @"
					DROP TRIGGER IF EXISTS arqs_alan.tgr_send_data_to_new_database;					
                ";

            migrationBuilder.Sql(dropTrigger);
        }
    }
}
