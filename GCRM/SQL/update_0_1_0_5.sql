-- Vamos a establecer el 0 como default para user_id 
-- y en todos los registros que tengan 'null' en esa variable se le aplicara un UPDATE para que tenga 0 
ALTER TABLE IF EXISTS public.settings
    ALTER COLUMN user_id SET DEFAULT 0;

UPDATE settings SET user_id =0 where user_id IS NULL;

-- update client version
UPDATE settings SET string_value = '0.1.0.5-alpha' WHERE name = 'client_version';