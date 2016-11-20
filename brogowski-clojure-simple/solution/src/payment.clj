(ns solution.payment)

(declare generate-packing-slip-stub)
(declare generate-duplicate-packaging-slip-stub)

(defn product-has-type?
  [product type]
  (let [types (:types product)]
    (some #{type} types)))

(defn recieve-payment
  ([payment]
    (recieve-payment payment generate-packing-slip-stub generate-duplicate-packaging-slip-stub))
  ([payment generate-packing-slip generate-duplicate-packaging-slip]
   (let
    [product (:product payment)]
    (when (product-has-type? product :physical)
      (generate-packing-slip product))
    (when (product-has-type? product :book)
      (generate-duplicate-packaging-slip product)))))

(defn generate-packing-slip-stub
  "Stub function for packaging slip generation/save/send."
  []())

(defn generate-duplicate-packaging-slip-stub
  "Stub function for duplicate packaging slip generation/save/send."
  []())