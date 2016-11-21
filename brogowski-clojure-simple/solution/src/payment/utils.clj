(ns payment.utils)

(defn product-has-type?
  [product type]
  (let [types (:types product)]
    (some #{type} types)))

(defn substract
  "Removes collection elements from other collection"
  [pred-coll coll]
  (remove #(some #{%} pred-coll) coll))

(defn product-has-title?
  [product expected-title]
  (let [title (:title product)]
    (= title expected-title)))

(defn product-has-any-type?
  [product expected-types]
  (let [product-types (:types product)]
    (< (count (substract product-types expected-types))
       (count expected-types))))