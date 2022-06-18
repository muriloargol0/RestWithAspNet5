FROM mysql:8.0
EXPOSE 3306
COPY ../db/migrations/ /home/database/
COPY ../db/dataset/ /home/database/
COPY ../ci/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh