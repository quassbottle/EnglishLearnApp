FROM rabbitmq:3.13-management

COPY ./rabbitmq_delayed_message_exchange-3.13.0.ez $RABBITMQ_HOME/plugins/rabbitmq_delayed_message_exchange-3.13.0.ez

RUN rabbitmq-plugins enable --offline rabbitmq_delayed_message_exchange

