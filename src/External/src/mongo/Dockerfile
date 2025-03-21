ARG APP_KEYFILE

FROM mongo:latest
ARG APP_KEYFILE
RUN openssl rand -base64 756 > $APP_KEYFILE
RUN chmod 400 $APP_KEYFILE
RUN chown mongodb:mongodb $APP_KEYFILE