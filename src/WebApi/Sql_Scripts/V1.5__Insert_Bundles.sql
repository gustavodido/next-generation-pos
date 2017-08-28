INSERT INTO bundles (id, discount) values (uuid_generate_v4(), 0.8);
INSERT INTO bundles (id, discount) values (uuid_generate_v4(), 0.5);

INSERT INTO bundle_products (bundle_id, product_id) values ((SELECT id from bundles where discount = 0.5), 'd2c19e21-5e50-4527-a836-874937c838e8');
INSERT INTO bundle_products (bundle_id, product_id) values ((SELECT id from bundles where discount = 0.5), '77bc6a96-c21b-43c1-bf2f-15bab88aa24a');
INSERT INTO bundle_products (bundle_id, product_id) values ((SELECT id from bundles where discount = 0.5), 'c33668eb-e0e2-45bf-953e-a5adc7b582a9');

INSERT INTO bundle_products (bundle_id, product_id) values ((SELECT id from bundles where discount = 0.8), 'be0408c4-1228-49b5-8747-e8e8d0cae958');
INSERT INTO bundle_products (bundle_id, product_id) values ((SELECT id from bundles where discount = 0.8), '691966bb-1328-4aa3-9d83-53d8e5b5bf49');
