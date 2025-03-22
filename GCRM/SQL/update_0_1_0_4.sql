-- citizen id index
CREATE INDEX citizen_id
    ON public.citizens USING btree
    (id ASC NULLS LAST)
    WITH (deduplicate_items=True)
;

-- citizen category id index
CREATE INDEX citizen_category_id
    ON public.citizen_categories USING btree
    (id)
    WITH (deduplicate_items=True)
;

-- address id index
CREATE INDEX address_id
    ON public.addresses USING btree
    (id)
    WITH (deduplicate_items=True)
;

-- institution id index
CREATE INDEX institution_id
    ON public.institutions USING btree
    (id)
    WITH (deduplicate_items=True)
;

-- institution category id index
CREATE INDEX institution_category_id
    ON public.institution_categories USING btree
    (id)
    WITH (deduplicate_items=True)
;

-- institution role id index
CREATE INDEX institution_role_id
    ON public.institution_roles USING btree
    (id)
    WITH (deduplicate_items=True)
;

-- citizen network citzen id
CREATE INDEX citizennetwork_citizen_id
    ON public.citizennetwork_citizens USING btree
    (id)
    WITH (deduplicate_items=True)
;

-- citizen network role id index
CREATE INDEX citzennetwork_role_id
    ON public.citizennetwork_roles USING btree
    (id)
    WITH (deduplicate_items=True)
;

-- citizen network id index
CREATE INDEX citizennetwork_id
    ON public.citizennetworks USING btree
    (id)
    WITH (deduplicate_items=True)
;

-- user id + user permission id index
CREATE INDEX "user_id+user_permission_id"
    ON public.user_permissions USING btree
    (user_id ASC NULLS LAST, id)
    WITH (deduplicate_items=True)
;

-- user id index
CREATE INDEX user_id
    ON public.users USING btree
    (id)
    WITH (deduplicate_items=True)
;

-- update client version
UPDATE settings SET string_value = '0.1.0.4-alpha' WHERE name = 'client_version';